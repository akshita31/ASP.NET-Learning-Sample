using System.Collections.Generic;
using SampleApplication.Models;

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

        private List<Restaraunt> _restaraunts;
    }
}