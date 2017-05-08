using OdeToFood2017.Entities;
using System.Collections.Generic;

namespace OdeToFood2017.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentGreeting { get; set; }
    }
}
