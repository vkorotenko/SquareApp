#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  06.06.2020 12:40
#endregion

using System;
using System.Globalization;
using Xamarin.Forms;

namespace SquareApp.Converters
{
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            var doubleValue = (double)value;
            return $"{doubleValue}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strValue = value as string;
            if (string.IsNullOrEmpty(strValue))
                return 0;

            if (double.TryParse(strValue, out var resultDecimal))
            {
                return resultDecimal;
            }
            return 0;
        }
    }
}
