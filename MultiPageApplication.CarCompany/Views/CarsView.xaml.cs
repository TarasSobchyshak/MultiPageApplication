using MultiPageApplication.CarCompany.Models;
using MultiPageApplication.CarCompany.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Linq;
using MultiPageApplication.CommonModels;

namespace MultiPageApplication.CarCompany.Views
{
    public sealed partial class CarsView : Page, INotifyPropertyChanged
    {
        public CarsView()
        {
            InitializeComponent();
        }

        private ObservableCollection<Car> _cars;
        private Car _selectedCar;
        private int _selectedCarIndex;
        private string _years;

        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set { SetProperty(ref _cars, value); }
        }
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set { SetProperty(ref _selectedCar, value); }
        }
        public int SelectedCarIndex
        {
            get { return _selectedCarIndex; }
            set { SetProperty(ref _selectedCarIndex, value); }
        }
        public string Years
        {
            get { return _years; }
            set { SetProperty(ref _years, value); }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            int pageKey = NavigationService.MainFrame.BackStackDepth;
            if (e.NavigationMode == NavigationMode.New) pageKey -= 1;
            if (e.NavigationMode == NavigationMode.Forward) pageKey -= 1;
            if (e.NavigationMode == NavigationMode.Back) pageKey += 1;
            StateDictionary.Dic[pageKey].Clear();
            StateDictionary.Dic[pageKey].Add(nameof(SelectedCar), SelectedCar);
            StateDictionary.Dic[pageKey].Add(nameof(SelectedCarIndex), SelectedCarIndex);

            base.OnNavigatedFrom(e);
        }
        private Dictionary<string, object> pageAttributes;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var year = (int)e.Parameter;
            Years = $"Car's of {year} - {year + 10}";
            year += 1900;
            Cars = new ObservableCollection<Car>(
                CarsFactory.GetItems().Where(c => c.Year >= year && c.Year <= (year + 10)));

            if (e.NavigationMode != NavigationMode.New)
            {
                int pageKey = NavigationService.MainFrame.BackStackDepth;
                pageAttributes = StateDictionary.Dic[pageKey];
                SelectedCar = pageAttributes[nameof(SelectedCar)] as Car;
                SelectedCarIndex = (int)(pageAttributes[nameof(SelectedCarIndex)]);
            }

            base.OnNavigatedTo(e);
        }

        private void BuyCar_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(BuyCarView), SelectedCar);
        }

        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            var changed = !EqualityComparer<T>.Default.Equals(backingField, value);
            if (changed)
            {
                backingField = value;
                RaisePropertyChanged(propertyName);
            }
            return changed;
        }
        #endregion
    }
}
