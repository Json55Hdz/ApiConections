using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTournaments : MonoBehaviour
{
    [SerializeField]
    private GetTorunamentsResponse responseTournamets;
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
        }
        else
        {

        }
    }


}
