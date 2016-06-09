using MultiPageApplication.CarCompany.Services;
using Windows.UI.Xaml.Controls;

namespace MultiPageApplication.CarCompany.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationService.MainFrame = pn.MainFrame;
        }
    }
}
