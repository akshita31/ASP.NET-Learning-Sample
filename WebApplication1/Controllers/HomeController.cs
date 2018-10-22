using System;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;

public class HomeController: Controller {
    //by default the basic reuest comes, the asp.net will instatntiate the HomeController class and call the Index 
    //method on it
    public IActionResult Index(string i){
        var model = new Restaraunt{Id = 1, Name= "Akshita"};
        //return new ObjectResult(model);
        return View(model);
    }
}