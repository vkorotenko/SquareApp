#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  06.06.2020 12:48
#endregion

using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace SquareApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var culture = new CultureInfo(1049);
            Resource.Culture = culture;// Set russian culture
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            MainPage = new SquarePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
