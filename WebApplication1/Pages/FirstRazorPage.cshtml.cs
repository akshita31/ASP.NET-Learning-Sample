using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApplication.Services;

namespace SampleApplication.Pages
{
    public class FirstRazorPageModel : PageModel
    {
        private IGreeter _greeter;

        public FirstRazorPageModel(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public string CurrentGreeting { get; private set; }

        public void OnGet()
        {
            CurrentGreeting = _greeter.GetMessage();
        }
    }
}