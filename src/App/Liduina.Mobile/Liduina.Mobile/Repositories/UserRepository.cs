using Liduina.DL.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liduina.Mobile.Repositories
{
    public class UserRepository : BaseRepository
    {

        public Task<User> GetUser()
        {
            return base.Get<User>("Users");
        }

		public Task<int> InsertUser(User user)
		{
			return base.Insert<User>("Users", user);
		}
    }
}
