using System.Collections.Generic;
using SampleApplication.Models;

namespace SampleApplication.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaraunt> GetAll();
        Restaraunt Get(int id);
    }
}