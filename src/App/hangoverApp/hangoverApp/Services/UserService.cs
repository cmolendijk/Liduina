using hangoverApp.Repositories;
using HangoverApp.DL.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangoverApp.Services
{
	public class UserService
	{
		private readonly UserRepository _userRepo;

		private static UserService _instance;
        private readonly AuthRepository _authRepo;

        public static UserService Instance
		{
			get
			{
				if (_instance == null)
					_instance = new UserService();
				return _instance;
			}
		}

		private UserService()
		{
			_userRepo = new UserRepository();
            _authRepo = new AuthRepository();
		}

		public Task<User> GetUsers()
		{
			return _userRepo.GetUser();
		}

		public async Task<int> SaveUser(User user)
		{
			if (user.Id <= 0)
			{
				var id = await _userRepo.InsertUser(user);
                await _authRepo.PerformLogin(user);
                return id;
			}
			else
			{
				return 0;
			}
		}

        public bool IsLoggedIn()
        {
            return _authRepo.IsLoggedIn();
        }
	}
}
