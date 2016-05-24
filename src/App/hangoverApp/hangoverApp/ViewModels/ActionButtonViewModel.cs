using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangoverApp.ViewModels
{
    public class ActionButtonViewModel : BaseViewModel
    {
        public int Id { get; }

        private int _index;

        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                RaisePropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
        
        private string _color;
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                RaisePropertyChanged();
            }
        }

        private IList<ActionViewModel> _actionViewModels;

        public IList<ActionViewModel> ActionViewModels
        {
            get { return _actionViewModels; }
            set
            {
                _actionViewModels = value;
                RaisePropertyChanged();
            }
        }
    }
}
