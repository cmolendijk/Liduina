using Android.App;
using Android.Content;
using Liduina.Mobile.DeviceServices;
using Liduina.Mobile.Droid.DeviceServices;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidNotificationService))]
namespace Liduina.Mobile.Droid.DeviceServices
{
    public class AndroidNotificationService : INotificationService
    {
        public void PostNotification(string title, string message)
        {
            var context = Xamarin.Forms.Forms.Context;
            var builder = new Notification.Builder(context)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSmallIcon(Resource.Drawable.icon);

            var notification = builder.Build();

            var manager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            manager.Notify(0, notification);
        }
    }
}