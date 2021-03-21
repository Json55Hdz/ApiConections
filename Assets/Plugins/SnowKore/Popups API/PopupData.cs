using UnityEngine;
using UnityEngine.Events;
using SnowKore.Utils;

[System.Serializable]
public class PopupData
{
    public System.Action OnGreenButtonPressedOverride;
    public System.Action OnRedButtonPressedOverride;

    [SerializeField]
    private string title;
    [SerializeField, TextArea]
    private string description;
    [SerializeField, Header("Green Button")]
    private string greenButtonText = "OK";
    [SerializeField]
    private UnityEvent OnGreenButtonPressed;
    [SerializeField, Header("Red Button")]
    private string redButtonText = "CANCELAR";
    [SerializeField]
    private UnityEvent OnRedButtonPressed;

    public UnityEvent redBtonPress => OnRedButtonPressed;

    private string[] replacements;

    public string Title
    {
        get { return title; }
    }

    public string Description
    {
        get { return description.ReplaceKeys(replacements); }
    }

    public string GreenButtonText
    {
        get { return greenButtonText; }
    }

    public string RedButtonText
    {
        get { return redButtonText; }
    }

    public void SetReplacements(params string[] replacements)
    {
        this.replacements = replacements;
    }

    public void OnGreenPressed()
    {
        OnGreenButtonPressedOverride?.Invoke();
        OnGreenButtonPressed?.Invoke();
    }

    public void OnRedPressed()
    {
        OnRedButtonPressedOverride?.Invoke();
        OnRedButtonPressed?.Invoke();
    }

    public void asingDescription (string description)
    {
        this.description = description;
    }

    public PopupData (string title, string description, System.Action GreenButtonPressed, System.Action RedButtonPressed)
    {
        this.title = title;
        this.description = description;
        greenButtonText = string.Empty;
        redButtonText = string.Empty;

        if (GreenButtonPressed != null)
        {
            greenButtonText = "OK";
            OnGreenButtonPressed = new UnityEvent();
            OnGreenButtonPressed.AddListener(GreenButtonPressed.Invoke);
        }

        if (RedButtonPressed != null)
        {
            redButtonText = "CANCEL";
            OnRedButtonPressed = new UnityEvent();
            OnRedButtonPressed.AddListener(redBtonPress.Invoke);
        }
    }

    public PopupData(string descrip,string title)
    {
        this.title = title;
        this.description = descrip;
    }
}
