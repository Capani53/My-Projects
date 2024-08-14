using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDtos;

namespace HiFiApp.Service.Abstract
{
    public interface ICategoryService
    {
        Task<Response<CategoryDto>> AddAsync(AddCategoryDto addCategoryDto);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<List<CategoryDto>>> GetActiveCategoriesAsync();
        Task<Response<List<CategoryDto>>> GetHomeCategoriesAsync();
        Task<Response<CategoryDto>> GetByIdAsync(int id);
        Task<Response<CategoryDto>> UpdateAsync(EditCategoryDto editCategoryDto);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}