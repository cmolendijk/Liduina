using hangoverApp.ViewModels;
using System;
using System.Reflection;
using Xamarin.Forms;

namespace hangoverApp.Views
{
    public partial class CreateUserView : CarouselPage
    {
        public CreateUserView()
        {
            BindingContext = new CreateUserViewModel(this.Navigation);
            InitializeComponent();

            var assembly = typeof(CreateUserView).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
        }

        public void Next_Click()
        {
            var pageCount = Children.Count;
            if (pageCount < 2)
                return;

            var index = Children.IndexOf(CurrentPage);
            index++;
            if (index >= pageCount)
                index = 0;

            CurrentPage = Children[index];
        }

        public void Previous_Click()
        {
            var pageCount = Children.Count;
            if (pageCount < 2)
                return;

            var index = Children.IndexOf(CurrentPage);
            index--;
            if (index < 0)
                index = 0;

            CurrentPage = Children[index];
        }

        public void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; //Deselection
        }
    }
}