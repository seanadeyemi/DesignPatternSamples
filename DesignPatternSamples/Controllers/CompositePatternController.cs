using Microsoft.AspNetCore.Mvc;
using File = DesignPatternSamples.Domain.Composite.File;
using Folder = DesignPatternSamples.Domain.Composite.File.Folder;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositePatternController : ControllerBase
    {

        public CompositePatternController()
        {

        }

        [HttpGet("CreateFileSystem")]
        public IActionResult CreateFileSystem()
        {

            // Create individual files
            var file1 = new File("file1.txt");
            var file2 = new File("file2.txt");

            // Create a folder and add files to it
            var folder1 = new Folder("Folder 1");
            folder1.AddItem(file1);
            folder1.AddItem(file2);

            // Create another individual file
            var file3 = new File("file3.txt");

            // Create another folder and add the file and the first folder to it
            var folder2 = new Folder("Folder 2");
            folder2.AddItem(file3);
            folder2.AddItem(folder1);

            // Display the entire directory tree
            var output = folder2.Display("");

            // Output:
            // + Folder 2
            //   file3.txt
            //   + Folder 1
            //     file1.txt
            //     file2.txt

            return Ok(output);

        }


    }

}

