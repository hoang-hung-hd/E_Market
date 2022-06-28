using Microsoft.AspNetCore.Mvc;

namespace Server_Back.Controllers
{
    public class UploadFileController : ControllerBase
    {
        private IWebHostEnvironment _hostEnv;

        public UploadFileController(IWebHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;
        }

        public IActionResult OnPostUpload(List<IFormFile> files)
        {
            /*long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }*/

            long size = files.Sum(f => f.Length);
            var fileDir = "Image";
            string filePath = Path.Combine(_hostEnv.WebRootPath, fileDir);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            foreach (var file in files)
            {
                var fileName = file.FileName;
                filePath = Path.Combine(filePath, fileName);
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fs);
                }
            }
            return Ok(new { count = files.Count, size });


            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.
        }
    }
}
