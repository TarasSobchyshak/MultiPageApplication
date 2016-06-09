using MultiPageApplication.CommonModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MultiPageApplication.CustomControls.PageNavigator
{
    public partial class PageNavigator : UserControl, INotifyPropertyChanged
    {
        public PageNavigator()
        {
            InitializeComponent();
            MainFrame = new Frame();
            MainFrame.SetValue(Grid.RowProperty, 1);
            gridName.Children.Add(MainFrame);
            DataContext = this;
            Back = new DelegateCommand<object>((obj) => { MainFrame_GoBack(); }, (obj) => MainFrame.CanGoBack);
            Forward = new DelegateCommand<object>((obj) => { MainFrame_GoForward(); }, (obj) => MainFrame.CanGoForward);
            ClearHistory = new DelegateCommand<object>((obj) => { MainFrame_ClearHistory(); }, (obj) => MainFrame.CanGoBack || MainFrame.CanGoForward);

            MainFrame.Navigated += MainFrame_Navigated;
        }

        private DelegateCommand<object> _back;
        private DelegateCommand<object> _forward;
        private DelegateCommand<object> _clearHistory;
        private Dictionary<string, object> pageAttributes;

        public DelegateCommand<object> ClearHistory
        {
            get { return _clearHistory; }
            set { SetProperty(ref _clearHistory, value); }
        }
        public DelegateCommand<object> Back
        {
            get { return _back; }
            set { SetProperty(ref _back, value); }
        }
        public DelegateCommand<object> Forward
        {
            get { return _forward; }
            set { SetProperty(ref _forward, value); }
        }

        public static readonly DependencyProperty MainFrameProperty =
            DependencyProperty.Register(nameof(MainFrame), typeof(Frame), typeof(PageNavigator), null);

        public Frame MainFrame
        {
            get { return (Frame)GetValue(MainFrameProperty); }
            set { SetValue(MainFrameProperty, value); }
        }
        private void Raise()
        {
            Back.RaiseCanExecuteChanged();
            Forward.RaiseCanExecuteChanged();
            ClearHistory.RaiseCanExecuteChanged();
        }
        private void MainFrame_ClearHistory()
        {
            MainFrame.BackStack.Clear();
            MainFrame.ForwardStack.Clear();
            Raise();
        }
        private void MainFrame_GoBack()
        {
            MainFrame.GoBack();
        }
        private void MainFrame_GoForward()
        {
            MainFrame.GoForward();
        }
        
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                int pageKey = MainFrame.BackStackDepth;

                for (int key = pageKey; StateDictionary.Dic.Remove(key); key++) ;

                pageAttributes = new Dictionary<string, object>();
                StateDictionary.Dic.Add(pageKey, pageAttributes);
            }

            Raise();
        }

        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
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
