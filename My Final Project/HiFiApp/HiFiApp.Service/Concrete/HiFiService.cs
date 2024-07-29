using AutoMapper;
using Azure.Identity;
using HiFiApp.Data.Abstract;
using HiFiApp.Entity.Concrete;
using HiFiApp.Service.Abstract;
using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Service.Concrete
{
    public class HiFiService : IHiFiService
    {
        private readonly IHiFiRepository _hiFiRepository;
        private readonly IMapper _mapper;

        public HiFiService(IHiFiRepository hiFiRepository, IMapper mapper)
        {
            _hiFiRepository=hiFiRepository;
            _mapper=mapper;
        }

        public async Task<Response<HiFiDto>> AddAsync(AddHiFiDto addHiFiDto)
        {
            var hiFi = _mapper.Map<HiFi>(addHiFiDto);     
            var createdHiFi = await _hiFiRepository.CreateHiFiWithCategoriesAsync(hiFi, addHiFiDto.CategoryIds);
            if (createdHiFi == null)
            {
                return Response<HiFiDto>.Fail("Bir sorun oluştu", 404);
            }            
            var hiFiDto = _mapper.Map<HiFiDto>(createdHiFi);
            return Response<HiFiDto>.Success(hiFiDto, 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var hiFi = await _hiFiRepository.GetByIdAsync(id);
            if (hiFi == null)
            {
                return Response<NoContent>.Fail("Böyle bir hifi bulunamadı", 404);
            }
            await _hiFiRepository.DeleteAsync(hiFi);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<HiFiDto>>> GetActiveHiFisAsync(bool isActive = true)
        {
            List<HiFi> hiFis = await _hiFiRepository.GetActiveHiFisAsync(isActive);
            if(hiFis.Count == 0)
            {
                return Response<List<HiFiDto>>.Fail("İstediğiniz kriterde hifi bulunamadı", 404);
            }
            var hiFiDtos = _mapper.Map<List<HiFiDto>>(hiFis);
            return Response<List<HiFiDto>>.Success(hiFiDtos, 200);
        }

        public async Task<Response<List<HiFiDto>>> GetAllAsync()
        {
            var hiFis = await _hiFiRepository.GetAllAsync();
            if (hiFis.Count == 0)
            {
                return Response<List<HiFiDto>>.Fail("Hiç hifi bulunamadı", 404);
            }
            var hiFiDtos = _mapper.Map<List<HiFiDto>>(hiFis);
            return Response<List<HiFiDto>>.Success(hiFiDtos, 200);
        }

        public async Task<Response<HiFiDto>> GetByIdAsync(int id)
        {
            var hiFi = await _hiFiRepository.GetHiFiWithCategoriesAsync(id);
            if(hiFi == null)
            {
                return Response<HiFiDto>.Fail("Böyle bir hifi bulunamadı", 404);
            }
            var hiFiDto = _mapper.Map<HiFiDto>(hiFi);
            return Response<HiFiDto>.Success(hiFiDto, 200);
        }

        public async Task<Response<List<HiFiDto>>> GetHiFisByCategoryIdAsync(int categoryId)
        {
            var hiFis = await _hiFiRepository.GetHiFisByCategoryIdAsync(categoryId);
            if (hiFis.Count == 0)
            {
                return Response<List<HiFiDto>>.Fail("Bu kategoride hiç hifi bulunamadı",404);
            }
            var hiFiDtos = _mapper.Map<List<HiFiDto>>(hiFis);
            return Response<List<HiFiDto>>.Success(hiFiDtos, 200);
        }
        public async Task<Response<List<HiFiDto>>> GetHiFisWithCategoriesAsync()
        {
            var hiFis = await _hiFiRepository.GetHiFisWithCategoriesAsync();
            if (hiFis.Count == 0)
            {
                return Response<List<HiFiDto>>.Fail("Hiç hifi bulunamadı", StatusCodes.Status404NotFound);
            }
            var hiFiDtos = _mapper.Map<List<HiFiDto>>(hiFis);
            return Response<List<HiFiDto>>.Success(hiFiDtos, StatusCodes.Status200OK);
        }

        public async Task<Response<List<HiFiDto>>> GetHomeHiFisAsync()
        {
            List<HiFi> hiFis = await _hiFiRepository.GetHomeHiFisAsync();
            if(hiFis.Count == 0)
            {
                return Response<List<HiFiDto>>.Fail("İstediğiniz kriterde hifi bulunamadı", 404);
            }
            var hiFiDtos = _mapper.Map<List<HiFiDto>>(hiFis);
            return Response<List<HiFiDto>>.Success(hiFiDtos, 200);
        }

        public async Task<Response<HiFiDto>> UpdateAsync(EditHiFiDto editHiFiDto)
        {
            var hiFi = _mapper.Map<HiFi>(editHiFiDto);
            if (hiFi == null)
            {
                return Response<HiFiDto>.Fail("Bir hata oluştu", 400);
            }
            hiFi.ModifiedDate= DateTime.Now;
            var updatedHiFi = await _hiFiRepository.UpdateAsync(hiFi);
            await _hiFiRepository.ClearHiFiCategoriesAsync(updatedHiFi.Id);
            updatedHiFi.HiFiCategories=editHiFiDto.CategoryIds.Select(categoryId=>new HiFiCategory{HiFiId=updatedHiFi.Id,CategoryId=categoryId}).ToList();
            await _hiFiRepository.UpdateAsync(updatedHiFi);
            var result = await _hiFiRepository.GetHiFiWithCategoriesAsync(updatedHiFi.Id);
            var hiFiDto = _mapper.Map<HiFiDto>(result);
            return Response<HiFiDto>.Success(hiFiDto, 200);
        }
    }
}
