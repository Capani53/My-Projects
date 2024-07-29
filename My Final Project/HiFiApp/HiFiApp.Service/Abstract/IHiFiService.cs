using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Service.Abstract
{
    public interface IHiFiService
    {
        Task<Response<HiFiDto>>AddAsync(AddHiFiDto addHiFiDto);
        Task<Response<List<HiFiDto>>> GetAllAsync();
        Task<Response<List<HiFiDto>>> GetHiFisWithCategoriesAsync();
        Task<Response<List<HiFiDto>>> GetHiFisByCategoryIdAsync(int categoryId);
        Task<Response<HiFiDto>> GetByIdAsync(int id);
        Task<Response<HiFiDto>> UpdateAsync(EditHiFiDto editHiFiDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<List<HiFiDto>>> GetActiveHiFisAsync(bool isActive=true);
        Task<Response<List<HiFiDto>>> GetHomeHiFisAsync();
    }
}