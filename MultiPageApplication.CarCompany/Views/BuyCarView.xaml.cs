using MultiPageApplication.CarCompany.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace MultiPageApplication.CarCompany.Views
{
    public sealed partial class BuyCarView : Page, INotifyPropertyChanged
    {
        public BuyCarView()
        {
            InitializeComponent();
        }

        private ObservableCollection<Car> _cars;

        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set { SetProperty(ref _cars, value); }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //int pageKey = NavigationService.MainFrame.BackStackDepth;
            //if (e.NavigationMode == NavigationMode.New) pageKey -= 1;
            //if (e.NavigationMode == NavigationMode.Back) pageKey += 1;
            //StateDictionary.Dic[pageKey].Clear();

            base.OnNavigatedFrom(e);
        }
        //private Dictionary<string, object> pageAttributes;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Car[] x = new Car[] { ((Car)(e.Parameter)) };
            Cars = new ObservableCollection<Car>(x);

            //if (e.NavigationMode != NavigationMode.New)
            //{
            //    int pageKey = NavigationService.MainFrame.BackStackDepth;
            //    pageAttributes = StateDictionary.Dic[pageKey];
            //}

            base.OnNavigatedTo(e);
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
