using AutoMapper;
using HiFiApp.Data.Abstract;
using HiFiApp.Entity.Concrete;
using HiFiApp.Service.Abstract;
using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Service.Concrete
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository=cartRepository;
            _mapper=mapper;
        }

        public async Task<Response<CartDto>> GetCartByUserIdAsync(string userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null) {
                return Response<CartDto>.Fail("İlgili kullanıcıya ait bir sepet bulunamadı!", 404);
            }
            var cartDto = _mapper.Map<CartDto>(cart);
            return Response<CartDto>.Success(_mapper.Map<CartDto>(cart), 200);
        }

        public async Task<Response<NoContent>> InitializeCartAsync(string userId)
        {
            var cart = new Cart { UserId=userId };
            await _cartRepository.CreateAsync(cart);
            return Response<NoContent>.Success(201);
        }
    }
}
