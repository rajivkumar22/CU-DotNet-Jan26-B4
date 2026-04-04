using Vagabond.Web.Models;

namespace Vagabond.Web.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();
    }
}