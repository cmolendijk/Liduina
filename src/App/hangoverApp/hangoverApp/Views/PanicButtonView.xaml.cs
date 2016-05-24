using hangoverApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace hangoverApp.Views
{
    public partial class PanicButtonView : ContentPage
    {
        public PanicButtonView()
        {
            BindingContext = new PanicButtonViewModel(this.Navigation);
            InitializeComponent();

            ToolbarItems.Add(new ToolbarItem("Nieuw", "ic_add_white_24dp.png", () => {
                Debug.WriteLine("Great, try again when I'm finished, stupid!");
            }));
        }
    }
}
