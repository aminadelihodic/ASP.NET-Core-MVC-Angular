using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace rentacar.Services
{
    public static class FileUploadHelper
    {
        public static string SaveUploadedFile(IFormFile SlikaUpload)
        {
            var wwwPath = "wwwroot";

            string path = Path.Combine(wwwPath, "Uploads");

            string fileName = Guid.NewGuid() + ".jpg";
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                SlikaUpload.CopyTo(stream);
            }

            return fileName;
        }
        public static void DeleteUploadedFile(string imageName)
        {
            var wwwPath = "wwwroot";

            string path = Path.Combine(wwwPath, imageName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        
    }
}
