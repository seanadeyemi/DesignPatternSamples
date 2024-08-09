using DesignPatternSamples.Domain.Decorator;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecoratorPatternController : ControllerBase
    {
        [HttpGet("TestDecorator")]
        public IActionResult TestDecorator()
        {
            IIceCream basicIceCream = new BasicIceCream();
            var basic = "Basic Ice Cream: " + basicIceCream.Make();

            IIceCream chocolateIceCream = new ChocolateFlavor(new BasicIceCream());
            var chocolate = "Chocolate Ice Cream: " + chocolateIceCream.Make();

            IIceCream sprinklesIceCream = new SprinklesTopping(new BasicIceCream());
            var sprinkles = "Ice Cream with Sprinkles: " + sprinklesIceCream.Make();

            IIceCream specialIceCream = new ChocolateFlavor(new SprinklesTopping(new BasicIceCream()));
            var special = "Special Ice Cream: " + specialIceCream.Make();

            // Output:
            // Basic Ice Cream
            // Chocolate Ice Cream: Basic Ice Cream + Chocolate Flavor
            // Ice Cream with Sprinkles: Basic Ice Cream + Sprinkles Topping
            // Special Ice Cream: Basic Ice Cream + Sprinkles Topping + Chocolate Flavor
            return Ok(new { basic, chocolate, sprinkles, special });
        }
    }
}
