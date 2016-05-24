using hangoverApp.ViewModels;

using Xamarin.Forms;

namespace hangoverApp.Views
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
