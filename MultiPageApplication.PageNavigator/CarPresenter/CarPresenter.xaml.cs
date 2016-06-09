using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MultiPageApplication.PageNavigator.CarPresenter
{
    public sealed partial class CarPresenter : UserControl
    {
        public CarPresenter()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register(nameof(Brand), typeof(string), typeof(CarPresenter), null);
        public static readonly DependencyProperty YearProperty = 
            DependencyProperty.Register(nameof(Year), typeof(int), typeof(CarPresenter), null);
        public static readonly DependencyProperty MileageProperty = 
            DependencyProperty.Register(nameof(Mileage), typeof(int), typeof(CarPresenter), null);
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register(nameof(Price), typeof(decimal), typeof(CarPresenter), null);

        public string Brand
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public int Year
        {
            get { return (int)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }
        public int Mileage
        {
            get { return (int)GetValue(MileageProperty); }
            set { SetValue(MileageProperty, value); }
        }
        public decimal Price
        {
            get { return (decimal)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
    }
}
