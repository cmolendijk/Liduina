using System;
using System.Globalization;
using Liduina.Mobile.DeviceServices;
using Liduina.Mobile.Droid.DeviceServices;

[assembly: Xamarin.Forms.Dependency(typeof(Localize))]
namespace Liduina.Mobile.Droid.DeviceServices
{
    /// <inheritdoc />
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            return new CultureInfo(netLanguage);
        }
    }
}