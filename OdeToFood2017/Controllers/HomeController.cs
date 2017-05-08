using Microsoft.AspNetCore.Mvc;
using OdeToFood2017.ViewModels;
using OdeToFood2017.Services;

namespace OdeToFood2017.Controllers
{
    public class HomeController: Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        //public ObjectResult Index()
        //{
        //    var model = new Restaurant { Id = 1, Name = "mac Donalds" };
        //    return new ObjectResult(model);
        //}
        public HomeController(IRestaurantData restaurantData,IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        public ViewResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentGreeting = _greeter.GetGreeting();
            return View(model);
        }
        public string Details(int id)
        {
            return id.ToString();
        }
    }
}
