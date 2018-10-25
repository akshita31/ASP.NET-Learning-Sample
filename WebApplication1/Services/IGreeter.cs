using Microsoft.Extensions.Configuration;

namespace SampleApplication.Services
{
    public interface IGreeter
    {
        string GetMessage();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
          _configuration = configuration;  
        }
        public string GetMessage()
        {
            return _configuration["Greeting"];
        }
    }
}