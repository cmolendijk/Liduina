using System;
using System.Collections.Generic;

namespace HangoverApp.DL.Models.ActionButton
{
    public class ActionButton
	{
		public int Id { get; set; }
		public String Title { get; set; }
		public String Color { get; set; }
		public int Index { get; set; }
		
		public ICollection<Action> Actions { get; set;  }
	}
}

