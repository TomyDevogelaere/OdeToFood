using Microsoft.AspNetCore.Mvc;
using OdeToFood2017.Models;

namespace OdeToFood2017.Controllers
{
    public class HomeController: Controller
    {
        //public ObjectResult Index()
        //{
        //    var model = new Restaurant { Id = 1, Name = "mac Donalds" };
        //    return new ObjectResult(model);
        //}
        public ViewResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "mac Donalds" };
            return View(model);
        }
    }
}
