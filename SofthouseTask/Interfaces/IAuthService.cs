using SofthouseTask.Models.Request;
using SofthouseTask.Models.Response;
using System.Threading.Tasks;

namespace SofthouseTask.Interfaces
{
    public interface IAuthService
    {
        public Task<UserDTO> LoginAsync(LoginDTO loginDTO);
    }
}
