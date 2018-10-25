using System;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;
using SampleApplication.Services;

public class HomeController: Controller {
    //by default the basic reuest comes, the asp.net will instatntiate the HomeController class and call the Index 
    //method on it

    public HomeController(IRestaurantData restaurantData)
    {
        _restaurantData = restaurantData;
    }
    public IActionResult Index(string i){
        var model = _restaurantData.GetAll();
        //return new ObjectResult(model);
        return View(model);
    
    }

    private IRestaurantData _restaurantData;
}