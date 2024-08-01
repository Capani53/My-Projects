using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Service.Abstract
{
    public interface IBrandService
    {
        Task<Response<BrandDto>> AddAsync(BrandDto addBrandDto);
        Task<Response<List<BrandDto>>> GetAllAsync();
        Task<Response<BrandDto>> GetByIdAsync(int id);
        Task<Response<BrandDto>> UpdateAsync(BrandDto editBrandDto);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
