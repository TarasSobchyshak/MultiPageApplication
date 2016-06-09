using MultiPageApplication.CarCompany.Services;
using MultiPageApplication.CommonModels;
using System.Collections.ObjectModel;

namespace MultiPageApplication.CarCompany.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
            MenuItems = MenuItemsFactory.GetItems();
        }

        public ObservableCollection<MenuItem> MenuItems { private set; get; }
    }

}
