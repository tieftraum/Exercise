using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise.Database;
using Exercise.Domain.Interfaces;
using Exercise.Domain.Records;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Infrastructure.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DataContext _context;

        public ManufacturerRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(int id)
        {
            return await _context.Manufacturers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddManufacturerAsync(Manufacturer manufacturer)
        {
            await _context.Manufacturers.AddAsync(manufacturer);
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer).State = EntityState.Modified;
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Remove(manufacturer);
        }
    }
}