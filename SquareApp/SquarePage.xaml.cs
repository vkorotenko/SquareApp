#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  06.06.2020 12:56

#endregion

using SquareApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SquareApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SquarePage : ContentPage
    {
        private readonly Model _vm;

        public SquarePage()
        {
            InitializeComponent();
            BindingContext = _vm = new Model();
        }

        private void OnButtonFocused(object sender, FocusEventArgs e)
        {
            if (sender is Entry cell) _vm.ActiveButton = cell.ReturnCommandParameter as string;
        }

        private class Model : BaseViewModel
        {
            private const double InitialMs = 1000;

            public Model()
            {
                Title = Resource.ConverterSquareTitle;
                ActiveButton = nameof(MsValue);
                MsValue = InitialMs;
            }

            #region Propertyes

            /*
            Квадратный метр (км2)       SquareMsLabel       MsValue
            Квадратный километр (км2)   SquareKmsLabel      KmValue
            Ар «соток» (а)              SquareArLabel       ArValue
            Гектар (га)                 SquareGaLabel       GaValue
            Акр                         SquareAcrLabel      AcrValue
            Квадратная миля             SquareMileLabel     MileValue
            Квадратный ярд (yd2)        SquareYardLabel     YardValue
            Квадратный фут (ft2)        SquareFtLabel       FtValue
             */

            private double Ms2Km() => MsValue / 1000000;


            private double Km2Ms() => KmValue * 1000000;

            private double Ms2Acr() => MsValue / 4046.86;

            private double Acr2Ms() => AcrValue * 4046.86;


            private double Ms2Ga() => MsValue / 10000;


            private double Ga2Ms() => GaValue * 10000;


            private double Ms2Ar() => MsValue / 100;

            private double Ar2Ms() => ArValue * 100;

            private double Ms2Mile() => MsValue / 1000000 / 2.58999;


            private double Mile2Ms() => MileValue * 2.58999 * 1000000;


            private double Ms2Yards() => MsValue * 1.19599;


            private double Yr2Ms() => YardValue / 1.19599;


            private double Ms2Ft() => MsValue * 10.7639;


            private double Ft2Ms() => FtValue / 10.7639;


            #region MsValue

            private double _ms = InitialMs;

            public double MsValue
            {
                get => _ms;
                set
                {
                    SetProperty(ref _ms, value);
                    if (ActiveButton != nameof(MsValue)) return;
                    SetValues();
                }
            }

            public void SetValues()
            {
                KmValue = Ms2Km();
                ArValue = Ms2Ar();
                GaValue = Ms2Ga();
                AcrValue = Ms2Acr();
                MileValue = Ms2Mile();
                YardValue = Ms2Yards();
                FtValue = Ms2Ft();
            }

            #endregion

            #region KmValue

            private double _km;

            public double KmValue
            {
                get => _km;
                set
                {
                    SetProperty(ref _km, value);
                    if (ActiveButton != nameof(KmValue)) return;
                    MsValue = Km2Ms();
                    SetValues();
                }
            }

            #endregion

            #region ArValue

            private double _arValue;

            public double ArValue
            {
                get => _arValue;
                set
                {
                    SetProperty(ref _arValue, value);
                    if (ActiveButton != nameof(ArValue)) return;
                    MsValue = Ar2Ms();
                    SetValues();
                }
            }

            #endregion

            #region GaValue

            private double _gaValue;

            public double GaValue
            {
                get => _gaValue;
                set
                {
                    SetProperty(ref _gaValue, value);
                    if (ActiveButton != nameof(GaValue)) return;
                    MsValue = Ga2Ms();
                    SetValues();
                }
            }

            #endregion

            #region AcrValue

            private double _acrValue;

            public double AcrValue
            {
                get => _acrValue;
                set
                {
                    SetProperty(ref _acrValue, value);
                    if (ActiveButton != nameof(AcrValue)) return;
                    MsValue = Acr2Ms();
                    SetValues();
                }
            }

            #endregion

            #region MileValue

            private double _mileValue;

            public double MileValue
            {
                get => _mileValue;
                set
                {
                    SetProperty(ref _mileValue, value);
                    if (ActiveButton != nameof(MileValue)) return;

                    MsValue = Mile2Ms();
                    SetValues();
                }
            }

            #endregion

            #region YardValue

            private double _yardValue;

            public double YardValue
            {
                get => _yardValue;
                set
                {
                    SetProperty(ref _yardValue, value);
                    if (ActiveButton != nameof(YardValue)) return;
                    MsValue = Yr2Ms();
                    SetValues();
                }
            }

            #endregion

            #region FtValue

            private double _ftValue;

            public double FtValue
            {
                get => _ftValue;
                set
                {
                    SetProperty(ref _ftValue, value);
                    if (ActiveButton != nameof(FtValue)) return;

                    MsValue = Ft2Ms();
                    SetValues();
                }
            }

            #endregion

            #endregion

            #region ActiveButton

            private string _activeButton = "";

            public string ActiveButton
            {
                get => _activeButton;
                set => SetProperty(ref _activeButton, value);
            }

            #endregion
        }
    }
}