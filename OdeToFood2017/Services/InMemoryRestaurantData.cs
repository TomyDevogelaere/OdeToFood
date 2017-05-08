using OdeToFood2017.Models;
using System.Collections.Generic;
using System;

namespace OdeToFood2017.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Max Donalds" },
                 new Restaurant { Id = 2, Name = "Quick" },
                 new Restaurant { Id = 3, Name = "Burger King" }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
