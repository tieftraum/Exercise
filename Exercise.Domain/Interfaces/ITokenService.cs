using System.Threading.Tasks;
using Exercise.Domain.Identity;

namespace Exercise.Domain.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}