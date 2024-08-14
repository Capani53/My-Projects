using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<Response<ImageDto>> Upload(IFormFile file,string directoryName);
    }
}
