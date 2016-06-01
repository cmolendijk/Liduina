using Liduina.Mobile.Services;
using Liduina.Mobile.Views;
using Liduina.DL.Enums;
using Liduina.DL.Models.Profile;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Liduina.Mobile.ViewModels
{
    public class CreateUserViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        public CreateUserViewModel(INavigation navigation)
        {
            _navigation = navigation;
            User = new User();
            UserTypes = new ObservableCollection<UserTypeListItemViewModel>();
            UserTypes.Add(new UserTypeListItemViewModel { Name = "Patient", IconFileName = "Patient" });
            UserTypes.Add(new UserTypeListItemViewModel { Name = "Helper", IconFileName = "Helper" });
            UserTypes.Add(new UserTypeListItemViewModel { Name = "Professional", IconFileName = "Professional" });
        }

        public ObservableCollection<UserTypeListItemViewModel> UserTypes { get; private set; }

        public string Title { get; } = "Registratie";

        public User User { get; set; }
        

        public Command RegisterCommand
        {
            get
            {
                return new Command(async p =>
                {
                    var selectedTypes = UserTypes.Where(t => t.IsSelected);
                    foreach (var usertype in selectedTypes)
                    {
                        if(usertype.Name.ToLower().Equals("patient"))
                        {
                            User.Type += (short)UserTypeEnum.Patient;
                        }
                        else if (usertype.Name.ToLower().Equals("helper"))
                        {
                            User.Type += (short)UserTypeEnum.Helper;
                        }
                        if (usertype.Name.ToLower().Equals("professional"))
                        {
                            User.Type += (short)UserTypeEnum.Professional;
                        }
                    }
                    //TODO: logic to execute here
                    UserTypeEnum total = (UserTypeEnum)User.Type;
                    await UserService.Instance.SaveUser(this.User);
                    App.Current.MainPage = new NavigationPage(new PanicButtonView());
                });
            }
        }
    }

    public class UserTypeListItemViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public bool IsSelected { get; private set; }
        public string IconFileName { get; set; }
        public ImageSource Icon
        {
            get { return ImageSource.FromResource(string.Format("Liduina.Mobile.Resources.{0}_{1}.png", IconFileName, IsSelected ? "Orange" : "Green")); }
        }

        public Command SelectUserTypeCommand { get { return new Command(unused => {
            IsSelected = !IsSelected;
            RaisePropertyChanged("Icon");
        }); } }
    }
}