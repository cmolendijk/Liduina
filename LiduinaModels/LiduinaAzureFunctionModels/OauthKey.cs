namespace LiduinaAzureFunctionModels
{
    public class OauthKey
    {
        public OauthKey(string userId, string agendaProvider)
        {
            RowKey = userId;
            PartitionKey = agendaProvider;
        }

        public OauthKey() { }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Key { get; set; }
    }
}
