using System.Security.Cryptography;
using WebApplicationManage.models.Order;

namespace WebApplicationManage.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<bool> AddOrder(OrderDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
