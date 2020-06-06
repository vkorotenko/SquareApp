#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  06.06.2020 12:46
#endregion

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SquareApp.Code
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var translation = Resource.ResourceManager.GetString(Text) ?? Text;
            return translation;
        }
    }
}
