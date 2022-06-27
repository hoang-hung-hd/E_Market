
using Server_Back.Models;

namespace Server_Back.Services
{
    public class UploadFileService
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        private ServerDbContext _context;
        public UploadFileService(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, ServerDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public void UploadFileToDatabase(List<IFormFile> postedFiles, Image_Response model)
        {
            string wwwPath = _environment.WebRootPath;
            string contentPath = _environment.ContentRootPath;

            string path = Path.Combine(_environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                Image_Request imageNew = new Image_Request();
                
                string fileName = Path.GetFileName(postedFile.FileName);
                imageNew.ImageName = fileName;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    _context.Images.Add(imageNew);
                }
            }

        }


    }
}
