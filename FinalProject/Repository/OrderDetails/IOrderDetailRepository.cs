using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetails
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetailDTO>> GetOrderDetails();
        Task<List<OrderDetailDTO>> GetOrderDetailsByOrder(int ordId);
        Task<OrderDetailCreateUpdateDTO> CreateOrderDetail(OrderDetailCreateUpdateDTO orderDetailDTO);
        Task<OrderDetailCreateUpdateDTO> UpdateOrderDetail(OrderDetailCreateUpdateDTO orderDetailDTO);

    }
}
