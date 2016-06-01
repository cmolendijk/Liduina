using Liduina.Mobile.Services;
using Liduina.Mobile.Views;
using Liduina.DL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Liduina.Mobile.ViewModels
{
    public class PanicButtonViewModel : BaseViewModel
    {
        public string Title { get { return "Hulpvraag uitzetten"; } }
        private ObservableCollection<PanicButtonListItemViewModel> _panicButtons = new ObservableCollection<PanicButtonListItemViewModel>();
        private readonly INavigation _navigation;

        public ObservableCollection<PanicButtonListItemViewModel> PanicButtons
        {
            get { return _panicButtons; }
            set
            {
                _panicButtons = value;
                RaisePropertyChanged();
            }
        }

        public PanicButtonViewModel(INavigation navigation)
        {
            _navigation = navigation;
            PanicButtons.Add(new PanicButtonListItemViewModel(
				new Liduina.DL.Models.Button { Id = 1, Name = "Het gaat beroerd",
					Actions = new List<ButtonAction>
					{
						new ButtonAction { Id = 1, Name = "Vrienden op de hoogte brengen" },
						new ButtonAction { Id = 2, Name = "Kat eten geven" }
					}
			}, _navigation));
        }
    }

    public class PanicButtonListItemViewModel
    {
        private readonly Liduina.DL.Models.Button _button;
        private readonly INavigation _navigation;

        public string Title { get { return _button.Name; } }
        public Command ExecuteButtonActionsCommand { get { return new Command(
            unused => {
				ButtonService.Instance.ExecuteButton(_button.Id);                
            }); } }

        public Command ConfigureButtonActionsCommand { get { return new Command(
            async unused => {
                await _navigation.PushAsync(new ConfigureButtonView(_button));
            }); } }

        public PanicButtonListItemViewModel(Liduina.DL.Models.Button button, INavigation navigation)
        {
            _button = button;
            _navigation = navigation;
        }
    }
}
