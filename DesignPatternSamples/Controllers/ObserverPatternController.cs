using DesignPatternSamples.Domain.Observer;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObserverPatternController : ControllerBase
    {
        //useful for instant notification ou rupdate scnarios where all observers need to be informed 
        //the instant an event occurs
        //examples of this concept include data binding in mvvm
        //signal r hub server and connected clients

        public IActionResult actionResult()
        {
            Subject subject = new Subject();

            IObserver observer1 = new ConcreteObserver("Observer 1");
            IObserver observer2 = new ConcreteObserver("Observer 2");

            subject.Attach(observer1);
            subject.Attach(observer2);

            var responses1 = subject.Notify("Hello observers!");

            subject.Detach(observer1);

            var responses2 = subject.Notify("Observer 1 detached.");

            subject.On<string>("arrive", async () =>
            {
                await Task.Delay(1000);
                return "called";
            });

            return Ok(new { responses1, responses2 });
        }
    }
}
