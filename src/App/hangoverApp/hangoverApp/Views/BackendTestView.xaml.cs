using hangoverApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace hangoverApp.Views
{
    public partial class BackendTestView : ContentPage
    {
        public BackendTestView()
        {
            InitializeComponent();
            BindingContext = new BackendTestViewModel();
        }
    }
}
