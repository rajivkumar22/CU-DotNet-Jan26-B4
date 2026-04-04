using Vagabond.Api.Exceptions;
using Vagabond.Api.Models;
using Vagabond.Api.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Vagabond.Api.Services
{
  

public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repo;

        public DestinationService(IDestinationRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new DestinationNotFoundException("Destination not found"); 

            return data;
        }

        public async Task AddAsync(Destination destination)
        {
            await _repo.AddAsync(destination);
        }

        public async Task UpdateAsync(Destination destination)
        {

            await _repo.UpdateAsync(destination);
        }

        public async Task DeleteAsync(int id)
        {

            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new DestinationNotFoundException("Destination not found");
            await _repo.DeleteAsync(id);
        }
    }
}

