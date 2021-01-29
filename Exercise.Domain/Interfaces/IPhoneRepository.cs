using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise.Domain.Records;

namespace Exercise.Domain.Interfaces
{
    public interface IPhoneRepository
    {
        Task<IEnumerable<Phone>> GetAllPhonesAsync();
        Task<Phone> GetPhoneByIdAsync(int id);
        Task AddPhoneAsync(Phone phone);
        void UpdatePhone(Phone phone);
        void DeletePhone(Phone phone);
    }
}