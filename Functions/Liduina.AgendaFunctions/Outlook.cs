using LiduinaAzureFunctionModels;
using Microsoft.Azure.WebJobs.Host;

namespace Liduina.AgendaFunctions
{
    public class Outlook
    {
        public static void Run(AgendaMessage agendaMessage, OauthKey oauthKey, TraceWriter log)
        {
            log.Info($"The following agendaMessage was received: {agendaMessage.RowKey}.");
        }
    }
}