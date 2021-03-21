using Newtonsoft.Json;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class GetTournaments : MonoBehaviour
{
    private GetTorunamentsResponse responseTournamets;

    [SerializeField]
    private TournamentsView tournamentsView;
    [SerializeField]
    private UnityEvent onTournamentsFinishGet;

    

    [EasyButtons.Button]
    public void GetTournamets ()
    {
        StartCoroutine(GetTournamentsPetition());
    }

    private IEnumerator GetTournamentsPetition ()
    {
        NotificationManager.Instance.SetupLoading();
        yield return new GetTournamentsServiceData().SendAsync(Response);
    }

    private void Response (string response,string code)
    {
        NotificationManager.Instance.HideNotification();
        if (code.Contains("200"))
        {
            responseTournamets = JsonConvert.DeserializeObject<GetTorunamentsResponse>(response);
            tournamentsView.SetTournamentResponses(responseTournamets);
            onTournamentsFinishGet.Invoke();
        }
        else
        {
            var notification = new NotificationContend("Ups!", "Something was wrong, pls check your connection and try again later.", "OK", null);
            NotificationManager.Instance.SetupSimpleNotification(notification);
        }
    }


}
