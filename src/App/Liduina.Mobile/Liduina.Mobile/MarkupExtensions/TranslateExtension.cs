using Liduina.Mobile.DeviceServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Liduina.Mobile.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo _ci;
        private const string _resourceId = "Liduina.Mobile.I18n.AppResources";

        public TranslateExtension()
        {
            _ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            var manager = new ResourceManager(_resourceId,
                typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = manager.GetString(Text, _ci);

            if(translation == null)
            {
#if DEBUG
                throw new ArgumentException($"Key [{Text}] was not found in resources [{_resourceId}] for culture [{_ci.Name}]");
#else
                translation = Text; //How in the world did you miss this in debug?
#endif
            }
            return translation;
        }
    }
}
