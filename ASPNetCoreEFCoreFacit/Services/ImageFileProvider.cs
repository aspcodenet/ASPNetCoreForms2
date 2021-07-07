using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ASPNetCoreEFCoreFacit.Services
{
    public class ImageFileProvider : IImageProvider
    {
        private readonly IWebHostEnvironment _environment;

        public ImageFileProvider(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public string GetBildSource(int itemId, DateTime lastModified)
        {
            var path = Path.Combine(_environment.WebRootPath, "UploadedFiles", "Kurser");

            foreach (var file in System.IO.Directory.GetFiles(path))
            {
                if (System.IO.Path.GetFileNameWithoutExtension(file) == itemId.ToString())
                    return "/UploadedFiles/Kurser/" + Path.GetFileName(file)
                                                    + "?cb=" + lastModified.ToString("yyyyMMddHHmmss");

            }

            return "";
        }

        public string GetSavingPathFor(int id, string uploadedFileName)
        {
            var ext = Path.GetExtension(uploadedFileName);
            string fileName = id.ToString() + ext;

            return Path.Combine(_environment.WebRootPath, "UploadedFiles", "Kurser", fileName);
        }

        public void RemoveExistingImages(int itemId)
        {
            var path = Path.Combine(_environment.WebRootPath, "UploadedFiles", "Kurser");

            foreach (var file in System.IO.Directory.GetFiles(path))
            {
                if (System.IO.Path.GetFileNameWithoutExtension(file) == itemId.ToString())
                {
                    System.IO.File.Delete(file);
                }
            }


        }
    }
}