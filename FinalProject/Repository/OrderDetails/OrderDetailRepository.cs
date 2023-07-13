using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetails
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IMapper _mapper;
        public OrderDetailRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<OrderDetailCreateUpdateDTO> CreateOrderDetail(OrderDetailCreateUpdateDTO orderDetailDTO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            return _mapper.Map<OrderDetailCreateUpdateDTO>(await OrderDetailDAO.CreateOrderDetail(orderDetail));
        }

        public async Task<List<OrderDetailDTO>> GetOrderDetails()
        {
            List<OrderDetail> orderDetails = await OrderDetailDAO.GetOrderDetails();
            List<OrderDetailDTO> orderDetailDTOs = _mapper.Map<List<OrderDetailDTO>>(orderDetails);

            return orderDetailDTOs;
        }

        public async Task<List<OrderDetailDTO>> GetOrderDetailsByOrder(int ordId)
        {
            List<OrderDetail> orderDetails = await OrderDetailDAO.GetOrderDetailsByOrder(ordId);
            List<OrderDetailDTO> orderDetailDTOs = _mapper.Map<List<OrderDetailDTO>>(orderDetails);

            return orderDetailDTOs;
        }

        public async Task<OrderDetailCreateUpdateDTO> UpdateOrderDetail(OrderDetailCreateUpdateDTO orderDetailDTO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            return _mapper.Map<OrderDetailCreateUpdateDTO>(await OrderDetailDAO.UpdateOrderDetail(orderDetail));
        }
    }
}
