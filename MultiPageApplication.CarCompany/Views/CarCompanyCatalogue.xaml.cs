using MultiPageApplication.CarCompany.Models;
using MultiPageApplication.CarCompany.Services;
using MultiPageApplication.CommonModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MultiPageApplication.CarCompany.Views
{
    public sealed partial class CarCompanyCatalogue : Page, INotifyPropertyChanged
    {
        public CarCompanyCatalogue()
        {
            InitializeComponent();
            TextValue = "Default text value";
        }

        private string _textValue;
        private ObservableCollection<Car> _cars;

        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set { SetProperty(ref _cars, value); }
        }
        public string TextValue
        {
            get { return _textValue; }
            set { SetProperty(ref _textValue, value); }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            int pageKey = NavigationService.MainFrame.BackStackDepth;
            if (e.NavigationMode == NavigationMode.New) pageKey -= 1;
            if (e.NavigationMode == NavigationMode.Forward) pageKey -= 1;
            if (e.NavigationMode == NavigationMode.Back) pageKey += 1;
            StateDictionary.Dic[pageKey].Clear();
            StateDictionary.Dic[pageKey].Add(nameof(TextValue), TextValue);

            base.OnNavigatedFrom(e);
        }
        private Dictionary<string, object> pageAttributes;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode != NavigationMode.New)
            {
                int pageKey = NavigationService.MainFrame.BackStackDepth;
                pageAttributes = StateDictionary.Dic[pageKey];
                TextValue = pageAttributes[nameof(TextValue)] as string;
            }

            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Cars = new ObservableCollection<Car>(
                CarsFactory.GetItems().Where(c => c.Brand == TextValue));
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
