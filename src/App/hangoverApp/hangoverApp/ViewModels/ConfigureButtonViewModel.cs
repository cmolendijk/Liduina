using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HangoverApp.DL.Models;
using System.Collections.ObjectModel;

namespace hangoverApp.ViewModels
{
    public class ConfigureButtonViewModel : BaseViewModel
    {
        private Button _button;

        private ObservableCollection<ButtonAction> _actions;
        public ObservableCollection<ButtonAction> Actions
        {
            get { return _actions; }
            set {
                _actions = value;
                RaisePropertyChanged();
            }

        }

        public string Title { get { return String.IsNullOrEmpty(_button.Name) ? "Nieuwe knop" : "Knop aanpassen"; } }

        public string ButtonName
        {
            get { return _button.Name; }
            set { _button.Name = value;
                RaisePropertyChanged();
            }
        }
        public ConfigureButtonViewModel(HangoverApp.DL.Models.Button button)
        {
            _button = button;
            Actions = new ObservableCollection<ButtonAction>(_button.Actions);
        }
    }
}
