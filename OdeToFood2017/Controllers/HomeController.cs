using Microsoft.AspNetCore.Mvc;
using OdeToFood2017.ViewModels;
using OdeToFood2017.Services;
using OdeToFood2017.Entities;

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
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisin;
                _restaurantData.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }
    }
}
