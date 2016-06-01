using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Liduina.DL.Models;
using Liduina.DL.Models.ActionButton;
using Liduina.DL.Providers;
using Liduina.DL.Services.Executables;

namespace Liduina.Backend.Controllers
{
    public class ExecuteController : ApiController
    {
        private readonly DbProvider _db = new DbProvider();
        
        [HttpGet]
        public ButtonResult Button(int buttonId)
        {
            IList<AidRequest> requests = getRequests(buttonId);
            IList<ButtonAction> actions = getActions(buttonId);

            if (requests != null)
            {
                foreach (AidRequest req in requests)
                {
                    Executable aanvraag = new ExecutableHulpaanvraag(req);
                    aanvraag.Execute(req.Id);
                }
            }
            if (actions != null)
            {
                foreach (ButtonAction action in actions)
                {
                    Executable actionExecutable = resolveActionByName(action);
                    actionExecutable.Execute(action.Id);
                }
            }

            return new ButtonResult();
        }

        private DateTime calcAbsoluteDateTime(TimeSlot timeSlot)
        {
            // get current date and time. 
            DateTime now = DateTime.Now;

            // Get current day of the week. 
            short dayNow = (short)now.DayOfWeek;

            // get day of week for timeslot. 
            short tSlotDay = timeSlot.Day;

            // calculate days difference between now and timeslot. 
            int dayDiff = Math.Abs(tSlotDay - dayNow);

            // create new DateTime based on now, plus the days to the next occurence and return it. 
            DateTime returnValue = new DateTime(now.Year, now.Month, now.Day, timeSlot.StartTime.Hour, timeSlot.StartTime.Minute, timeSlot.StartTime.Second);
            returnValue.AddDays(dayDiff);

            return returnValue;
        }

        /*
			GetHelpRequests: 
				all hulpvragen -> A
				for(hVr : A)
					calcAbsoluteDateTimes -> hVrSet
					for (hv : hVrSet)

						hv.startDatumTijd <= time() <= hv.eindDatumTijd ? 
						hv.vanWie.count() > 0 ? 

				return subSet
			*/
        private IList<AidRequest> getRequests(int buttonId)
        {
            IList<AidRequest> requestList = new List<AidRequest>();

            Button aidButton = _db.Button.Find(buttonId);

            if (aidButton == null)
            {
                return null;
            }

            DateTime eindTijd = DateTime.Now.AddHours(aidButton.TillHours);
            IQueryable<AidRequest> resultSet = _db.ButtonAidRequests.Where(x => x.ButtonId == buttonId).Select(x => x.AidRequest);
            IList<AidRequest> list = resultSet.ToList();

            foreach (AidRequest element in list)
            {
                foreach (TimeSlot ts in element.TimeSlots)
                {
                    DateTime absDateTime = calcAbsoluteDateTime(ts);

                    if (absDateTime < eindTijd && element.AidProviders.Any())
                        requestList.Add(element);
                }
            }

            return requestList;
        }

        private IList<ButtonAction> getActions(int buttonId)
        {
            Button aidButton = _db.Button.Find(buttonId);
            return aidButton?.Actions.ToList();
        }

        private Executable resolveActionByName(ButtonAction action)
        {
            if (action.ActionType.Name.Equals("SendMessage"))
                return new ExecutableActionSendMessage(action);

            return null;
        }

        /*
		   GetHelpRequests(buttonId) -> A
		   GetActions(buttonId) -> B

		   for(actie : B)
			   actie.execute()

		   for(hulpvraag : A)
			   hulpvraag.execute()
		   */



        /*
		Match all helpers to requester: 
		FindHelpers(waarmee, loc, requesterId)
			helpers -> A
			for(helper : A)
				helper.aanbod.waarmee == waarmee
				helper.aanbod.maxDist >= helper.loc - loc
				helper.aanbod.voorwie.contains(requesterId) or contains("anonymous")

			return subset. 
			
		*/
    }
}
