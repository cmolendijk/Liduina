using HangoverApp.DL.Models;
using HangoverApp.DL.Providers;
using System.Collections.Generic;
using System.Linq;

namespace HangoverApp.DL.Services.Executables
{
	public class ExecutableHulpaanvraag : Executable
	{
		private DbProvider db = new DbProvider();

		public AidRequest AidReq { get; set;  }

		public ExecutableHulpaanvraag(AidRequest req)
		{
			AidReq = req;
		}

		public IEnumerable<AidProvider> MatchHelpersToAidRequest(AidRequest request)
		{
			Models.Profile.User requestee = request.User;
			IEnumerable<AidProvider> aidProviders = request.AidProviders.Where(ap => ap.AidOffers.Any(ao => request.Activities.All(a => ao.Activities.Contains(a))
																										 && ao.Contacts.Any(c => c.User == requestee)
																										 && ao.ActionsLeftThisMonth > 0));
			return aidProviders;
		}


		private SendRequest createSendRequest(AidProvider provider)
		{
			SendRequest req = new SendRequest();

			req.AidProvider = provider;
			req.Status = Status.Sent;

			db.SendRequests.Add(req);
			db.SaveChanges();

			return req;
		}

		public void Execute(int aidReqId)
		{
			// get aanvraag by ID. 
			AidRequest req = db.AidRequests.Find(aidReqId);

			// get available helpers. 
			IEnumerable<AidProvider> aiders = MatchHelpersToAidRequest(req);


			// for each helper: 
			ICollection<SendRequest> sentReqSet = new List<SendRequest>();

			foreach (AidProvider aider in aiders)
			{
				// create a SendRequest. 
				SendRequest sendReq = createSendRequest(aider);
				sentReqSet.Add(sendReq);
			}

			// create uitgestuurde hulp aanvraag. 
			SendAidRequest reqSet = new SendAidRequest();
			reqSet.AidRequest = req;
			reqSet.Status = Status.Sent;
			reqSet.SendRequests = sentReqSet;

			db.SendAidRequests.Add(reqSet);
			db.SaveChanges();
		}
	}
}
