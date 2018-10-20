using System;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]/[action]")]
public class AboutController{
    //by default the basic reuest comes, the asp.net will instatntiate the HomeController class and call the Index 
    //method on it

    
    public string AboutMe(string i){
        return $"hello from about controller - {i}";
    }

    public string Address()
    {
        return "Canada";
    }
}