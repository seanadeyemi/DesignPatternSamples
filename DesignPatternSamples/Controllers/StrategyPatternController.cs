using DesignPatternSamples.Domain.Strategy;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategyPatternController : ControllerBase
    {
        public IActionResult actionResult()
        {
            //change the behaviour based on the parameter passed in
            //polymorphism as promised

            IShippingStrategy standardShipping = new StandardShippingStrategy();
            IShippingStrategy expressShipping = new ExpressShippingStrategy();

            ShoppingCart cart = new ShoppingCart(standardShipping);
            double totalCost = cart.CalculateTotalCost(100.0, 10.0);
            var costWithStandardShipping = "Total cost with standard shipping: " + totalCost;

            cart = new ShoppingCart(expressShipping);
            totalCost = cart.CalculateTotalCost(100.0, 10.0);
            var costWithExpressShipping = "Total cost with express shipping: " + totalCost;


            return Ok(new { costWithStandardShipping, costWithExpressShipping });
        }
    }
}
