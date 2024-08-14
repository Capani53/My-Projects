using HiFiApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFiApp.Shared.Dtos;

namespace HiFiApp.Service.Abstract
{
    public interface IHiFiService
    {
        Task<Response<HiFiDto>> AddAsync(AddHiFiDto addHiFiDto);
        Task<Response<List<HiFiDto>>> GetAllAsync();
        Task<Response<List<HiFiDto>>> GetHiFiWithCategoriesAsync();
        Task<Response<List<HiFiDto>>> GetHiFiByCategoryIdAsync(int categoryId);
        Task<Response<HiFiDto>> GetByIdAsync(int id);
        Task<Response<HiFiDto>> UpdateAsync(EditHiFiDto editHiFiDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<List<HiFiDto>>> GetActiveHiFiAsync(bool isActive = true);
        Task<Response<List<HiFiDto>>> GetHomeHiFiAsync();
    }
}
