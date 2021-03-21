using UnityEngine;
using UnityEngine.UI;
public class PrefabTournamentView : MonoBehaviour
{
    [SerializeField]
    private Text id, date;

    public void SetupPrefabTournamentView(string id, string date)
    {
        this.id.text = $"Tournament ID:\n{id}";
        this.date.text = $"Tournament Date:\n{date}";
    }
}
