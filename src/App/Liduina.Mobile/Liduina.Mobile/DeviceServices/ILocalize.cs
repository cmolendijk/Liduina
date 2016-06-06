using System.Globalization;

namespace Liduina.Mobile.DeviceServices
{
    /// <summary>
    /// Resource localizator.
    /// Needs to be implemented for iOS and Android to show translated strings depending on OS language.
    /// Windows (Phone) is not required to implement this, but implementing this interface allows access from XAML.
    /// For more info, check https://developer.xamarin.com/guides/xamarin-forms/advanced/localization/
    /// </summary>
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
