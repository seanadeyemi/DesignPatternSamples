using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamplesTestController : ControllerBase
    {
        private readonly SomeReader _someReader;
        public SamplesTestController(SomeReader someReader)
        {
            _someReader = someReader;
        }


        [HttpGet]
        public FileStreamResult GetTest()
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes("Hello World"));
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "test.txt"
            };
        }


        [HttpGet]
        public async Task Get()
        {
            Response.ContentType = "text/plain";
            StreamWriter sw;
            await using ((sw = new StreamWriter(Response.Body)).ConfigureAwait(false))
            {
                foreach (var item in _someReader.Read())
                {
                    await sw.WriteLineAsync(item.ToString()).ConfigureAwait(false);
                    await sw.FlushAsync().ConfigureAwait(false);
                }
            }
        }

        [HttpGet]
        public async Task GetAgain()
        {
            Response.ContentType = "text/plain";
            StreamWriter sw;
            await using ((sw = new StreamWriter(Response.Body)).ConfigureAwait(false))
            {
                var someReader = new SomeReader2();

                await foreach (var item in someReader.Read())
                {
                    await sw.WriteLineAsync(item.ToString()).ConfigureAwait(false);
                    await sw.FlushAsync().ConfigureAwait(false);
                }
            }
        }

    }

    public class SomeReader
    {
        private StreamReader _streamReader;

        public SomeReader(string filePath)
        {
            _streamReader = new StreamReader(filePath);
        }

        public string Read()
        {
            return _streamReader.ReadLine();
        }
    }

    public class SomeReader2
    {
        private List<string> _data = new List<string> { "Data1", "Data2", "Data3", "Data4", "Data5" };

        public async IAsyncEnumerable<string> Read()
        {
            foreach (var item in _data)
            {
                await Task.Delay(1000); // Simulate some delay
                yield return item;
            }
        }
    }

}
