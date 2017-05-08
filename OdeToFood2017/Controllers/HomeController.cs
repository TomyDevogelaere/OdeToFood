using Microsoft.AspNetCore.Mvc;
using OdeToFood2017.Models;
using OdeToFood2017.Services;

namespace OdeToFood2017.Controllers
{
    public class HomeController: Controller
    {
        private IRestaurantData _restaurantData;

        //public ObjectResult Index()
        //{
        //    var model = new Restaurant { Id = 1, Name = "mac Donalds" };
        //    return new ObjectResult(model);
        //}
        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public ViewResult Index()
        {
            var model = _restaurantData.GetAll();
            return View(model);
        }
    }
}
