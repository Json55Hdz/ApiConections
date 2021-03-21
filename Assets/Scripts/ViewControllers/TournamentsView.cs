using UnityEngine;
using UnityEngine.UIElements;

public class TournamentsView : MonoBehaviour
{
    [SerializeField]
    private PrefabTournamentView tournamentView;
    [SerializeField]
    private Transform ContainerTournaments;

    private GetTorunamentsResponse torunamentsResponse;

    public void SetupInstantiation ()
    {
        CleanOldTournaments();
        InstantiateTournaments();
    }

    private void CleanOldTournaments ()
    {
        foreach (Transform child in ContainerTournaments)
            Destroy(child.gameObject);        
    }

    private void InstantiateTournaments ()
    {
        foreach (var item in torunamentsResponse.data)
        {
            var Instantiated = Instantiate(tournamentView, ContainerTournaments);
            Instantiated.SetupPrefabTournamentView(item.id,item.attributes.createdAt.ToString());
        }
    }

    public void SetTournamentResponses (GetTorunamentsResponse torunamentsResponse)
    {
        this.torunamentsResponse = torunamentsResponse;
    }
}
