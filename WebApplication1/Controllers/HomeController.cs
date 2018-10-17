using System;

public class HomeController{
    //by default the basic reuest comes, the asp.net will instatntiate the HomeController class and call the Index 
    //method on it
    public string Index(){
        return "hello from home controller";
    }
}