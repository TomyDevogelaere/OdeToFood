using Microsoft.AspNetCore.Mvc;
using OdeToFood2017.ViewModels;
using OdeToFood2017.Services;
using OdeToFood2017.Entities;
using Microsoft.AspNetCore.Authorization;

namespace OdeToFood2017.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = new HomePageViewModel()
            {
                Restaurants = _restaurantData.GetAll(),
                CurrentGreeting = _greeter.GetGreeting()
            };
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
                var restaurant = new Restaurant()
                {
                    Name = model.Name,
                    Cuisine = model.Cuisin
                };
                _restaurantData.Add(restaurant);
                _restaurantData.Commit();
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id,RestaurantEditViewModel input)
        {
            var restaurant = _restaurantData.Get(id);
            if (restaurant != null && ModelState.IsValid)
            {
                restaurant.Name = input.Name;
                restaurant.Cuisine = input.Cuisin;
                _restaurantData.Commit();
            }
            return RedirectToAction("Details", new { id = restaurant.Id});
        }
    }
}
