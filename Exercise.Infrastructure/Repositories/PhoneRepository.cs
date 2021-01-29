using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise.Database;
using Exercise.Domain.Interfaces;
using Exercise.Domain.Records;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Infrastructure.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly DataContext _context;

        public PhoneRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Phone>> GetAllPhonesAsync()
        {
            return await _context.Phones.ToListAsync();
        }

        public async Task<Phone> GetPhoneByIdAsync(int id)
        {
            return await _context.Phones.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddPhoneAsync(Phone phone)
        {
            await _context.Phones.AddAsync(phone);
        }

        public void UpdatePhone(Phone phone)
        {
            _context.Entry(phone).State = EntityState.Modified;
        }

        public void DeletePhone(Phone phone)
        {
            _context.Phones.Remove(phone);
        }
    }
}