using Vagabond.Api.Data;
using Vagabond.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Vagabond.Api.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly VagabondApiContext _context;

        public DestinationRepository(VagabondApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
            => await _context.Destinations.ToListAsync();

        public async Task<Destination> GetByIdAsync(int id)
            => await _context.Destinations.FindAsync(id);

        public async Task AddAsync(Destination destination)
        {
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Destinations.FindAsync(id);
            if (data != null)
            {
                _context.Destinations.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
