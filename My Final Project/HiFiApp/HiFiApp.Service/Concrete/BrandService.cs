using AutoMapper;
using HiFiApp.Data.Abstract;
using HiFiApp.Service.Abstract;
using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Service.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public Task<Response<BrandDto>> AddAsync(BrandDto addBrandDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<BrandDto>>> GetAllAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            if (brands == null)
            {
                return Response<List<BrandDto>>.Fail("Bir sorun oluştu",StatusCodes.Status400BadRequest);
            }
            if (brands.Count == 0)
            {
                return Response<List<BrandDto>>.Success(StatusCodes.Status204NoContent);
            }
            var brandDtoList =_mapper.Map<List<BrandDto>>(brands);
            return Response<List<BrandDto>>.Success(brandDtoList,StatusCodes.Status200OK);
        }

        public Task<Response<BrandDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<BrandDto>> UpdateAsync(BrandDto editBrandDto)
        {
            throw new NotImplementedException();
        }
    }
}
