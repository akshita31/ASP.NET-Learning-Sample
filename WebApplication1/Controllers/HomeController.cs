using System;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;

public class HomeController: Controller {
    //by default the basic reuest comes, the asp.net will instatntiate the HomeController class and call the Index 
    //method on it
    public IActionResult Index(string i){
        return new ObjectResult(new Restaraunt(1, "Akshita"));
    }
}