using WebApplicationManage.Data;
using WebApplicationManage.models.Customer;
using WebApplicationManage.models.Order;

namespace WebApplicationManage.Repositories
{
    public interface IOrderRepository
    {
        public Task<Boolean> AddOrder(OrderDto dto);

        public Task<List<OrderAll>> GetAllOrder();

        public Task<List<OrderAll>> GetOrderByCustomerId(int id);
    }
}
