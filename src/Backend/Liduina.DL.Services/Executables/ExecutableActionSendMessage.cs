using Liduina.DL.Models;
using Liduina.DL.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLSharp.Core;

namespace Liduina.DL.Services.Executables
{
	public class ExecutableActionSendMessage : Executable
	{
		private DbProvider db = new DbProvider();

		public ButtonAction Action { get; set; }

		public ExecutableActionSendMessage(ButtonAction act)
		{
			Action = act; 
		}

		public async void Execute(int buttonActionId)
		{
			var message = GetMessageToSend(buttonActionId);
			var phoneNumbers = GetPhoneNumbers(buttonActionId);

			var store = new FileSessionStore();
			var client = new TelegramClient(store, "session", 36596, "fbc3440667919b266d2975f4c022fdb4");
			await client.Connect();
			foreach (var phoneNumber in phoneNumbers)
			{
				var phoneRegistered = await client.IsPhoneRegistered(phoneNumber);
				if (phoneRegistered)
				{
					var userId = await client.ImportContactByPhoneNumber(phoneNumber);
					if (userId.HasValue)
					{
						await client.SendMessage(userId.Value, message);
					}
				}
			}
		}

		private string GetMessageToSend(int buttonActionId)
		{
			var messageToSend = (from ba in db.ButtonActions
								join cf in db.Configurations on ba.Id equals cf.ButtonActionId
								join ck in db.ConfigurationKeys on ba.ActionTypeId equals ck.ActionTypeId
								where ck.Name == "Message" && ba.Id == buttonActionId
								select cf.Value).SingleOrDefault();

			return messageToSend;
		}

		private IList<string> GetPhoneNumbers(int buttonActionId)
		{
			var phoneNumbers = (from ba in db.ButtonActions
								 join cf in db.Configurations on ba.Id equals cf.ButtonActionId
								 join ck in db.ConfigurationKeys on ba.ActionTypeId equals ck.ActionTypeId
								 where ck.Name == "PhoneNumber" && ba.Id == buttonActionId
								 select cf.Value).ToList();

			return phoneNumbers;
		}
	}
}
