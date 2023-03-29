using WebApplicationManage.models.Producer;
using WebApplicationManage.models.Token;
using WebApplicationManage.models.User;

namespace WebApplicationManage.Repositories
{
    public interface IProducerRepository
    {
        public Task<Boolean> AddProducer(ProducerDto dto);
        public Task<List<ProducerDto>> GetProducersAsync();
        public Task<ProducerDto> GetProducerById(int id);
        public Task<Boolean> UpdateProducerAsync(int id, ProducerDto producer);
        public Task<Boolean> DeleteProducerAsync(int id);
    }
}
