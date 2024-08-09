using DesignPatternSamples.Domain.Transactional;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionalOrSagaPatternController : ControllerBase
    {
        public IActionResult actionResult()
        {
            //If any one step fails, all fail. All or nothing
            //the collective success of all depends on everyone's success in sequence 

            var process = new TransactionalProcess();
            process.AddStep(new Step1());
            process.AddStep(new Step2());
            process.AddStep(new Step3());

            var result = process.Execute();
            return Ok(result);
        }
    }
}
