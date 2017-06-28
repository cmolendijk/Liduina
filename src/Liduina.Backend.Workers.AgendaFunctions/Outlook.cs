using Liduina.Backend.Shared.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;

namespace Liduina.Backend.Workers.AgendaFunctions
{
    public static class Outlook
    {
        [FunctionName("agendaMessage")]
        public static void Run([ServiceBusTrigger("agendatopic", "Outlook", AccessRights.Manage, Connection = "AzureWebJobsServiceBus")]AgendaMessage agendaMessage, TraceWriter log)
        {
            log.Info($"C# ServiceBus topic trigger function processed message with row key: {agendaMessage.RowKey}");
        }
    }
}