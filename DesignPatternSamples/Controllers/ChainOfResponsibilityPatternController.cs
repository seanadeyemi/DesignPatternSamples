using DesignPatternSamples.Domain.ChainOfResponsibility;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChainOfResponsibilityPatternController : ControllerBase
    {
        public IActionResult actionResult()
        {
            Handler handlerA = new ConcreteHandlerA();
            Handler handlerB = new ConcreteHandlerB();
            Handler handlerC = new ConcreteHandlerC();

            handlerA.SetNextHandler(handlerB);
            handlerB.SetNextHandler(handlerC);

            handlerA.HandleRequest(5);
            handlerA.HandleRequest(15);
            handlerA.HandleRequest(25);


            return Ok();
        }
    }
}
