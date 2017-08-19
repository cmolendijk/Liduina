using Microsoft.WindowsAzure.Storage.Table;

namespace Liduina.Backend.Shared.Models
{
    public class OauthKey : TableEntity
    {
        public OauthKey(string userId, string agendaProvider)
        {
            RowKey = userId;
            PartitionKey = agendaProvider;
        }

        public OauthKey() { }
        
        public string Key { get; set; }
    }
}
