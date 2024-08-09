using DesignPatternSamples.Domain.Reducer;
using Microsoft.AspNetCore.Mvc;
using static DesignPatternSamples.Domain.Reducer.ReducerPatternExample;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReducerPatternController : ControllerBase
    {
        [HttpGet]
        public IActionResult actionResult()
        {

            AppState currentState = new AppState { Counter = 0 };
            var stateInfo1 = "Current Counter: " + currentState.Counter;

            currentState = ReducerPatternExample.Reducer(currentState, ActionType.Increment);
            var stateInfo2 = "Counter after Increment: " + currentState.Counter;

            currentState = ReducerPatternExample.Reducer(currentState, ActionType.Decrement);
            var stateInfo3 = "Counter after Decrement: " + currentState.Counter;


            return Ok(new { stateInfo1, stateInfo2, stateInfo3 });
        }
    }
}
