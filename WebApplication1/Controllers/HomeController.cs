using System;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;
using SampleApplication.Services;
using SampleApplication.ViewModels;

public class HomeController: Controller {
    //by default the basic reuest comes, the asp.net will instatntiate the HomeController class and call the Index 
    //method on it
    private IRestaurantData _restaurantData;
    private IGreeter _greeter;
    public HomeController(IRestaurantData restaurantData, IGreeter greeter)
    {
        _restaurantData = restaurantData;
        _greeter = greeter;
    }

    public IActionResult Index(){
        var model = new HomeIndexViewModel();
        model.Restaraunts =  _restaurantData.GetAll();
        model.Message = _greeter.GetMessage();
        //return new ObjectResult(model);
        return View(model);
    }

    public IActionResult Details(int id)
    {
        var model = _restaurantData.Get(id);
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }
}