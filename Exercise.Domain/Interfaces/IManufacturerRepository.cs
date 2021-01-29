using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise.Domain.Records;

namespace Exercise.Domain.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();
        Task<Manufacturer> GetManufacturerByIdAsync(int id);
        Task AddManufacturerAsync(Manufacturer manufacturer);
        void UpdateManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
    }
}