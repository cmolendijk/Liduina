using Liduina.Mobile.Device;
using Liduina.Mobile.Services;
using Liduina.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Liduina.Mobile.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
		public MainPageViewModel(INavigation nav)
		{
			_navigation = nav;
            _userService = UserService.Instance;
            PerformLogin.Execute(null);
		}

		public string LoadingText { get; } = "Bezig met laden...";
        private bool _isLoading = false;
        public bool IsLoading {
            get { return _isLoading; }
            set {
                _isLoading = value;
                RaisePropertyChanged();
            }
        }
        
		private readonly INavigation _navigation;
        private readonly UserService _userService;

		public ICommand PerformLogin
		{
			get
			{
				return new Command(async unused =>
				{
                    //TODO: Sign in if user is known, redirect if user is unknown
                    IsLoading = true;
                    await Task.Delay(2000);
                    if (!_userService.IsLoggedIn())
                        App.Current.MainPage = new NavigationPage(new CreateUserView());
                    else
                        App.Current.MainPage = new NavigationPage(new PanicButtonView());
                    
                    IsLoading = false;
				});
			}
		}
	}
}
