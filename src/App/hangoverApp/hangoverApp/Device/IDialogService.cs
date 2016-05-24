using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangoverApp.Device
{
    public interface IDialogService
    {
        void ShowNotificationPopup(string title, string message);
    }
}
