using HiFiApp.Shared.Helpers.Abstract;
using HiFiApp.Shared.ResponseDto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private string _imagesFolder = "wwwroot";
        private readonly string[] permittedExtensions = { ".png", ".jpg", ".jpeg" };
        private readonly string[] permittedMimeTypes = { "image/png", "image/jpg", "image/jpeg" };
        public ImageHelper(IWebHostEnvironment env)
        {
            _imagesFolder = Path.Combine(env.WebRootPath, "images");
        }
        public async Task<Response<string>> Upload(IFormFile file)
        {
           if (file == null || file.Length==0)
            {
                return Response<string>.Fail("Resim dosyasında sorun var!",401);
            }
           var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (String.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
            {
                return Response<string>.Fail("Resim formatı hatalı. png, jpg, ya da jpeg gönderiniz.", 401);
            }
            if (!permittedMimeTypes.Contains(file.ContentType))
            {
                return Response<string>.Fail("Lütfen resim dosyası içeriğini kontrol ediniz.", 401);
            }

            if(!Directory.Exists(_imagesFolder))
            {
                Directory.CreateDirectory(_imagesFolder);
            }
            var fileName = $"{Guid.NewGuid()}{extension}";
            //var fileName = Path.Combine(Guid.NewGuid().ToString(), extension);
            var fullPath= Path.Combine(_imagesFolder, fileName);
            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                 await file.CopyToAsync(stream);
            };


            return Response<string>.Success($"/images/{fileName}", 201);
        }
    }
}
