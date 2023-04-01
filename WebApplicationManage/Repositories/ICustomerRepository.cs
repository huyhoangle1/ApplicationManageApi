using WebApplicationManage.models.Customer;


namespace WebApplicationManage.Repositories
{
    public interface ICustomerRepository
    {
        public Task<CustomerDto> LoginCustomer(LoginCustomerDto dto);
        public Task<Boolean> RegisterCustomer(RegisterCustomerDto dto);
        public Task<List<CustomerDto>> GetCustomerList();
        public Task<CustomerDto> GetCustomerId(int id);
        public Task<Boolean> UpdateCustomerAsync(int id, CustomerDto customer);
        public Task<Boolean> DeleteCustomerAsync(int id);
    }
}
