using System;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;
using SampleApplication.Services;
using SampleApplication.ViewModels;
using WebApplication1.ViewModels;

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

    //This method should respond to a get request and render the form   
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    //This method should respond to a POST request and save the restaurant information
    public IActionResult Create(RestarauntEditModel model)
    {
        var restaraunt = new Restaraunt();
        restaraunt.Name = model.Name;
        restaraunt.Cuisine = model.Cuisine;

        var newRestaurant = _restaurantData.Add(restaraunt);

        //Here instead of returning an HTML as a result of a post we do a redirect
        // If we dont do redirect then when we refresh a page then the post action will be repeated and data may become duplicated or inconsistent
        //This is the POST-REDIRECT-GET pattern
        return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
    }
}