using System;
using System.Threading.Tasks;


public static void Run(string agendaMessage, OauthKey oauthKey, TraceWriter log)
{
    log.Info($"C# ServiceBus topic trigger function processed message: {agendaMessage}");
}

public class OauthKey
{
    public OauthKey(string userId, string agendaProvider)
    {
        RowKey = userId;
        PartitionKey = agendaProvider;
    }

    public OauthKey() {}

    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Key { get; set; }
}
