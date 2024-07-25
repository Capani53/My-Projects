using HiFiApp.Shared.ResponseDto;
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
        Task<Response<string>> Upload(IFormFile file);
    }
}
