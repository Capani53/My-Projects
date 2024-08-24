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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository=orderRepository;
            _mapper=mapper;
        }

        public async Task<Response<int>> CreateAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.CreateAsync(order);
            return Response<int>.Success(order.Id,201);
        }

        public async Task<Response<List<OrderDto>>> GetOrdersAsync(string? userId = null)
        {
            var orders = await _orderRepository.GetAllOrdersAsync(userId);
            var orderDtoList = _mapper.Map<List<OrderDto>>(orders);
            return Response<List<OrderDto>>.Success(orderDtoList, 200);
        }

        public async Task<Response<OrderDto>> GetOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            var orderDto = _mapper.Map<OrderDto>(order);
            return Response<OrderDto>.Success(orderDto,200);
        }
    }
}
