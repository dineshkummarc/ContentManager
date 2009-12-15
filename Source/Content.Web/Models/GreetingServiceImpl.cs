
namespace NinjectIntegration.Models
{
    public class GreetingServiceImpl : IGreetingService
    {
        #region IGreetingService Members

        public string GetGreeting()
        {
            return "Hello from the Greeting Service concrete implementation!";
        }

        #endregion
    }

    public interface IGreetingService
    {
        string GetGreeting();
    }
}
