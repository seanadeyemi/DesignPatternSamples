using DesignPatternSamples.Domain.Visitor;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorPatternController : ControllerBase
    {
        [HttpGet]
        public IActionResult actionResult()
        {
            List<IElement> elements = new List<IElement>
            {
                new ConcreteElementA(),
                new ConcreteElementB()
            };

            IVisitor visitor = new ConcreteVisitor();

            foreach (var element in elements)
            {
                element.Accept(visitor);
            }


            return Ok();
        }






    }
}
