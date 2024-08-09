using Microsoft.AspNetCore.Mvc;
using static DesignPatternSamples.Domain.NullObject.Toys;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NullObjectDesignPatternController : ControllerBase
    {
        [HttpGet("TestNullObject")]
        public IActionResult TestNullObject()
        {
            ToyCollection toyCollection = new ToyCollection();

            // Adding real toys to the collection
            var toy1 = new RealToy("Car");
            var toy2 = new RealToy("Doll");
            toyCollection.AddToy(toy1, toy1.Name);
            toyCollection.AddToy(toy2, toy2.Name);

            // Trying to find a toy that exists
            IToy existingToy = toyCollection.GetToyByName("Car");
            var t1 = existingToy.Display();

            // Trying to find a toy that doesn't exist
            IToy missingToy = toyCollection.GetToyByName("Train");
            var t2 = missingToy.Display();

            // Output:
            // This is a real toy called Car.
            // Sorry, this toy doesn't exist in the collection.

            return Ok(new { t1, t2 });
        }
    }
}
