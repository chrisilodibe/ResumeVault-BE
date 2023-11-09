using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Core.Services.Implementations
{    public class FileService
    {
        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/pdf";

            if (file.Length > fiveMegaByte || file.ContentType != pdfMimeType)
            {
                throw new Exception("File is not valid");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Documents", "Pdfs", resumeUrl);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return resumeUrl;
        }
    }

}
