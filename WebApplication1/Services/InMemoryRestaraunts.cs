using System.Collections.Generic;
using SampleApplication.Models;
using System.Linq;

namespace SampleApplication.Services
{
    public class InMemoryRestaraunt : IRestaurantData
    {

        public InMemoryRestaraunt()
        {
            _restaraunts = new List<Restaraunt>{
                 new Restaraunt { Id =1 , Name=  "Hello"},
                 new Restaraunt { Id =2 , Name=  "Hell"}
            };
        }
        public IEnumerable<Restaraunt> GetAll()
        {
            return _restaraunts;
        }

        public Restaraunt Get(int id)
        {
            return _restaraunts.FirstOrDefault(r => r.Id == id);
        }

        private List<Restaraunt> _restaraunts;
    }
}