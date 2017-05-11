using Microsoft.AspNetCore.Mvc;
using OdeToFood2017.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OdeToFood2017.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
        int Commit();
    }
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }
        public void Add(Restaurant restaurant)
        {
            _context.Add(restaurant);
        }

        public int Commit()
        {
         return  _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
          return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
       static List<Restaurant> _restaurants;
        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Max Donalds" },
                 new Restaurant { Id = 2, Name = "Quick" },
                 new Restaurant { Id = 3, Name = "Burger King" }
            };
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
       
        public void Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
        }

        public int Commit()
        {
           return 0;
        }
    }
}
