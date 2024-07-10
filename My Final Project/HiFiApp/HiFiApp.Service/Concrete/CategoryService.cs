using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Data.Abstract;
using HiFiApp.Entity.Concrete;
using HiFiApp.Service.Abstract;
using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDto;

namespace HiFiApp.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<CategoryDto>> AddAsync(AddCategoryDto addCategoryDto)
        {
            Category category = new Category{
                Name=addCategoryDto.Name,
                Description=addCategoryDto.Description
            };
            Category createdCategory = await _categoryRepository.CreateAsync(category);
            if(createdCategory==null){
                return Response<CategoryDto>.Fail("Veri tabanına kayıt işlemi sırasında bir sorun oluştu",404);
            }
            CategoryDto categoryDto = new CategoryDto{
                id=createdCategory.id,
                CreatedDate=createdCategory.CreatedDate,
                ModifiedDate=createdCategory.ModifiedDate,
                Description=createdCategory.Description,
                IsActive=createdCategory.IsActive,
                Name=createdCategory.Name,
            };
            return Response<CategoryDto>.Success(categoryDto,201);
        }

        public Task<Response<List<CategoryDto>>> GetActiveCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}