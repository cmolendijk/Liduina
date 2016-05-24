using hangoverApp.Services;
using HangoverApp.DL.Models.Profile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hangoverApp.ViewModels
{
    public class BackendTestViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users { get { return _users; }
            set {
                _users = value;
                RaisePropertyChanged();
            } }
        public Command GetUsersCommand { get { return new Command(async
            p => {
                var response = await UserService.Instance.GetUsers();
                
                Users.Add(response);
            }); } }
    }
}
