namespace Liduina.AzureFunctionModels
{
    public class AgendaMessage
    {
        public AgendaMessage(string rowKey)
        {
            RowKey = rowKey;
        }

        public AgendaMessage() { }

        public string RowKey { get; set; }
    }
}
