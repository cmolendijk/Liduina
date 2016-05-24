
using Android.App;
using hangoverApp.Device;
using Android.Support.Design.Widget;
using hangoverApp.Droid.Device;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDialogService))]
namespace hangoverApp.Droid.Device
{
    class AndroidDialogService : IDialogService
    {
        public void ShowNotificationPopup(string title, string message)
        {
            var context = Xamarin.Forms.Forms.Context;
            Snackbar.Make(((Activity)context).Window.DecorView.FindViewById(Android.Resource.Id.Content), message, 2000).Show();
        }
    }
}