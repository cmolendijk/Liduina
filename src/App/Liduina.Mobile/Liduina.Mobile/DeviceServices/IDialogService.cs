using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liduina.Mobile.DeviceServices
{
    public interface IDialogService
    {
        void ShowNotificationPopup(string title, string message);
    }
}
