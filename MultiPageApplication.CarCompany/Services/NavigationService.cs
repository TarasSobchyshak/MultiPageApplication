using System;
using Windows.UI.Xaml.Controls;

namespace MultiPageApplication.CarCompany.Services
{
    public static class NavigationService
    {
        public static Frame MainFrame { get; set; }

        public static bool Navigate(Type sourcePageType)
        {
            return MainFrame.Navigate(sourcePageType);
        }

        public static bool Navigate(Type sourcePageType, object parameter)
        {
            return MainFrame.Navigate(sourcePageType, parameter);
        }
    }
}
