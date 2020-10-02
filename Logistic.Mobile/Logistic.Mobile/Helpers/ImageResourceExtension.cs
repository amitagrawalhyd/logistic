using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Logistic.Mobile.Helpers
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Source)) return null;
            return ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        }
    }
}
