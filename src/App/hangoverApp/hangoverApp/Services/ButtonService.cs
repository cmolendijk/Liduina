using hangoverApp.Repositories;
using HangoverApp.DL.Models.Profile;
using System.Threading.Tasks;

namespace hangoverApp.Services
{
	public class ButtonService
	{
		private readonly ButtonRepository _buttonRepo;

		private static ButtonService _instance;
        private readonly AuthRepository _authRepo;

        public static ButtonService Instance
		{
			get
			{
				if (_instance == null)
					_instance = new ButtonService();
				return _instance;
			}
		}

		private ButtonService()
		{
			_buttonRepo = new ButtonRepository();
		}

		public void ExecuteButton(int buttonId)
		{
			_buttonRepo.ExecuteButton(buttonId);
		}
	}
}
