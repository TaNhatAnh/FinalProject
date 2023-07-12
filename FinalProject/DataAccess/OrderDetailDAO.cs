using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        public static async Task<List<OrderDetail>> GetOrderDetails()
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new MyDBContext())
                {
                    listOrderDetails = await context.OrderDetails.Include(x => x.Product).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrderDetails;
        }

        public static async Task<List<OrderDetail>> GetOrderDetailsByOrder(int ordId)
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new MyDBContext())
                {
                    listOrderDetails = await context.OrderDetails.Where(x => x.OrderId == ordId).Include(x => x.Product).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrderDetails;
        }

        public static async Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    await context.OrderDetails.AddAsync(orderDetail);
                    await context.SaveChangesAsync();

                    return await context.OrderDetails.Include(x => x.Product).SingleOrDefaultAsync(x => x.ProductId == orderDetail.ProductId && x.OrderId == orderDetail.OrderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    context.Entry<OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await context.SaveChangesAsync();

                    return await context.OrderDetails.Include(x => x.Product).SingleOrDefaultAsync(x => x.ProductId == orderDetail.ProductId && x.OrderId == orderDetail.OrderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
