using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangoverApp.Device
{
    public interface INotificationService
    {
        void PostNotification(string title, string message);
    }
}
