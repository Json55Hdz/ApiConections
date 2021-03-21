using System;
using System.Collections.Generic;

[System.Serializable]
public class GetTorunamentsResponse
{
    public List<Datum> data;
}

[System.Serializable]
public class Datum
{
    public string type;
    public string id;
    public Attributes attributes;
}

public class Attributes
{
    public DateTime createdAt;
}