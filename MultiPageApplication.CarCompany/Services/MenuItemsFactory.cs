using MultiPageApplication.CarCompany.Views;
using MultiPageApplication.CommonModels;
using System.Collections.ObjectModel;
using static MultiPageApplication.CarCompany.Services.NavigationService;

namespace MultiPageApplication.CarCompany.Services
{
    public static class MenuItemsFactory
    {
        public static ObservableCollection<MenuItem> GetItems()
        {
            var items = new ObservableCollection<MenuItem>()
            {
                new MenuItem
                {
                    Text = "Home",
                    Command = new DelegateCommand<object>((obj) => Navigate(typeof(CarCompanyCatalogue)))
                },
                new MenuItem
                {
                    Text = "Cars of 40's",
                    Command = new DelegateCommand<object>((obj) => Navigate(typeof(CarsView), 40))
                },                                                                            
                new MenuItem                                                                  
                {                                                                             
                    Text = "Cars of 50's",                                                    
                    Command = new DelegateCommand<object>((obj) => Navigate(typeof(CarsView), 50))
                },                                                                            
                new MenuItem                                                                  
                {                                                                             
                    Text = "Cars of 60's",                                                    
                    Command = new DelegateCommand<object>((obj) => Navigate(typeof(CarsView), 60))
                },                                                                            
                new MenuItem                                                                  
                {                                                                             
                    Text = "Cars of 70's",                                                    
                    Command = new DelegateCommand<object>((obj) => Navigate(typeof(CarsView), 70))
                },
                new MenuItem
                {
                    Text = "Cars of 80's",
                    Command = new DelegateCommand<object>((obj) => Navigate(typeof(CarsView), 80))
                },
                new MenuItem
                {
                    Text = "Cars of 90's",
                    Command = new DelegateCommand<object>((obj) => Navigate(typeof(CarsView), 90))
                }
            };

            return items;
        }
    }
}
