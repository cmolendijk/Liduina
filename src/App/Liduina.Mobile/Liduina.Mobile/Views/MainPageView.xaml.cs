using Liduina.Mobile.ViewModels;

using Xamarin.Forms;

namespace Liduina.Mobile.Views
{
    public partial class MainPageView : ContentPage
    {
        public MainPageView()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(this.Navigation);
        }
    }
}
