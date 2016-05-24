using HangoverApp.DL.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace hangoverApp.Repositories
{
    public class AuthRepository
    {

        private readonly AccountStore _store;

        public AuthRepository()
        {
            _store = AccountStore.Create();
        }
        public async Task<Account> PerformLogin(User user)
        {
            var localUser = _store.FindAccountsForService("hangover").FirstOrDefault(u => u.Username.Equals(user.Email));

            if(localUser == null)
            {
                localUser = new Account(user.Email);
            }

            localUser.Properties.Add("access_token", string.Empty); //TODO: Gimme token...

            await _store.SaveAsync(localUser, "hangover");
            return localUser;
        }

        public bool IsLoggedIn()
        {
            var user = _store.FindAccountsForService("hangover").FirstOrDefault();

            return user != null; // && user.Properties["access_token"] != null; //Existing user with access_token.
        }

        public void Logout(string username)
        {
            _store.Delete(new Account { Username = username }, "hangover");
        }
    }
}
