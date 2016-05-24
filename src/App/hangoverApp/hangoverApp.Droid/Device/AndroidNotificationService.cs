using System;
using hangoverApp.Device;
using Android.App;
using Android.Content;
using hangoverApp.Droid.Device;

[assembly: Xamarin.Forms.Dependency(typeof (AndroidNotificationService))]
namespace hangoverApp.Droid.Device
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