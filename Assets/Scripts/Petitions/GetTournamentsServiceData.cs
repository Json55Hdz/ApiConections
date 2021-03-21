using SnowKore.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTournamentsServiceData : NewServiceData
{
    public GetTournamentsServiceData()
    {
    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            return body;
        }
    }

    protected override string ServiceURL => "tournaments";

    protected override Dictionary<string, object> Params
    {
        get
        {
            Dictionary<string, object> paramsDic = new Dictionary<string, object>();
            return paramsDic;
        }
    }

    protected override Dictionary<string, string> Headers
    {
        get
        {
            Dictionary<string, string> retHeaders = new Dictionary<string, string>
            {
                { "accept", "application/vnd.api+json" },
                {"Authorization","Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiIxZjllZGJkMC02OWIzLTAxMzktMDE4My02MzRlMzFhMmYyYjgiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjE2MDI5MTcyLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6Ii03NWY1MDI4OC0zN2VkLTRmY2YtOTQxZC1iOWQ1OTBmMTY1Y2QifQ.LMcv-4BtJ2NSOY6FmneWXOOj7vohC1VZvJRBH5sY0fQ" }
            };
            return retHeaders;
        }
    }

    protected override ServiceType ServiceType => ServiceType.GET;
}
