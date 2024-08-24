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
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper, ICartRepository cartRepository)
        {
            _cartItemRepository=cartItemRepository;
            _mapper=mapper;
            _cartRepository=cartRepository;
        }

        public async Task<Response<NoContent>> AddToCartAsync(AddToCartDto addToCartDto)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(addToCartDto.UserId);
            if (cart == null)
            {
                return Response<NoContent>.Fail("Bir hata oluştu", 400);
            }
            int index = cart.CartItems.FindIndex(x => x.HiFiId==addToCartDto.HiFiId);
            if(index<0)
            {
                cart.CartItems.Add(new CartItem
                {
                     HiFiId = addToCartDto.HiFiId,
                     CartId=cart.Id,
                     Quantity=addToCartDto.Quantity
                });
            }
            else
            {
                cart.CartItems[index].Quantity=addToCartDto.Quantity;
            }
            await _cartRepository.UpdateAsync(cart);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> ChangeQuantityAsync(int cartItemId, int quantity)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            cartItem.Quantity= quantity;
            await _cartItemRepository.UpdateAsync(cartItem);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> ClearCartAsync(string userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            cart.CartItems = new List<CartItem>();
            await _cartRepository.UpdateAsync(cart);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteItemFromCartAsync(int cartItemId)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            await _cartItemRepository.DeleteAsync(cartItem);
            return Response<NoContent>.Success(200);
        }
    }
}
