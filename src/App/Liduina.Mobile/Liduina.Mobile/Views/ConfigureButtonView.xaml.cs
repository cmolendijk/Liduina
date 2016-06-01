using Liduina.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Liduina.Mobile.Views
{
    public partial class ConfigureButtonView : ContentPage
    {
        public ConfigureButtonView(Liduina.DL.Models.Button button = null)
        {
            if (button == null)
                button = new Liduina.DL.Models.Button();

            BindingContext = new ConfigureButtonViewModel(button);
            InitializeComponent();

            ToolbarItems.Add(new ToolbarItem("Nieuw", "ic_add_white_24dp.png", () => {
                Debug.WriteLine("Great, try again when I'm finished, stupid!");
            }));
        }
    }
}
