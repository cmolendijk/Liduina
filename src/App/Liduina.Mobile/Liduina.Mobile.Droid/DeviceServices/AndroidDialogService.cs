
using Android.App;
using Android.Support.Design.Widget;
using Liduina.Mobile.Droid.DeviceServices;
using Liduina.Mobile.DeviceServices;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDialogService))]
namespace Liduina.Mobile.Droid.DeviceServices
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