using UnityEngine.UI;
using UnityEngine;
using DoozyUI;
using System;

public class NotificationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject simpleContainer,loadingContainer;
    [SerializeField]
    private Text title, description, buttonText;
    [SerializeField]
    private UIButton button;
    [SerializeField]
    private UIElement notificationElement;

    public static NotificationManager Instance;

    private Action action;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void ResetAction()
    {
        action = null;
        action += HideNotification;
    }

    private void ShowNotification()
    {
        notificationElement.Show(true);
    }
    public void HideNotification()
    {
        notificationElement.Hide(true);
    }
    public void SetupLoading ()
    {
        simpleContainer.SetActive(false);
        loadingContainer.SetActive(true);
        ShowNotification();
    }

    public void SetupSimpleNotification(NotificationContend contend)
    {
        simpleContainer.SetActive(true);
        loadingContainer.SetActive(false);
        ResetAction();
        title.text = contend.title;
        description.text = contend.description;
        buttonText.text = contend.buttontext;
        action += contend.actionButton;
        button.OnClick.AddListener(() => action.Invoke());
        ShowNotification();
    }
}

public class NotificationContend
{
    public string title, description, buttontext = "Ok";
    public Action actionButton;

    public NotificationContend(string title, string description, string buttontext, Action actionButton)
    {
        this.title = title;
        this.description = description;
        if (!string.IsNullOrEmpty(buttontext))
            this.buttontext = buttontext;
        if (actionButton != null)
            this.actionButton = actionButton;
    }
}
