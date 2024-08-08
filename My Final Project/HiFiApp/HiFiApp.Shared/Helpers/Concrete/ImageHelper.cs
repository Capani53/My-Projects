﻿using HiFiApp.Shared.Dtos;
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
        private string _imagesFolder;
        private readonly string[] permittedExtensions = { ".png", ".jpg", ".jpeg" };
        private readonly string[] permittedMimeTypes = { "image/png", "image/jpg", "image/jpeg" };
        public ImageHelper(IWebHostEnvironment env)
        {
            _imagesFolder = Path.Combine(env.WebRootPath, "images");
        }

        public async Task<Response<ImageDto>> Upload(IFormFile file, string directoryName)
        {
            if (file == null || file.Length == 0)
            {
                return Response<ImageDto>.Fail("Resim dosyasında sorun var!", 401);
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (String.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
            {
                return Response<ImageDto>.Fail("Resim formatı hatalı. png, jpg ya da jpeg gönderiniz.", 401);
            }

            _imagesFolder = Path.Combine(_imagesFolder, directoryName);
            if (!Directory.Exists(_imagesFolder))
            {
                Directory.CreateDirectory(_imagesFolder);
            }

            var fileName = $"{Guid.NewGuid()}{extension}";

            var fullPath = Path.Combine(_imagesFolder, fileName);

            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            };
            var result = new ImageDto { ImageUrl = $"images/{directoryName}/{fileName}" };
            return Response<ImageDto>.Success(result, 201);
        } 
    }
}
