using System.Collections.Generic;
using System.Linq;
using SampleApplication.Data;
using SampleApplication.Models;

namespace SampleApplication.Services{
    public class SqlRestaurant : IRestaurantData
    {
        private SampleApplicationDbContext _context;

        public SqlRestaurant(SampleApplicationDbContext context)
        {
            _context = context;
        }

        public Restaraunt Add(Restaraunt restaraunt)
        {
            _context.Restaurants.Add(restaraunt);
            _context.SaveChanges();
            return restaraunt;
        }

        public Restaraunt Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaraunt> GetAll()
        {
            return _context.Restaurants;
        }
    }
}