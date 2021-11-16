using SofthouseTask.Models.Request;
using SofthouseTask.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SofthouseTask.Interfaces
{
    public interface IJobApplicationService
    {
        public Task<bool> AddApplicationAsync(JobApplicationDTO payload);
        public Task<byte[]> GetApplicationCvAsync(int id);
        public Task<IEnumerable<JobApplicationInfoDTO>> GetApplicationsAsync();
        public Task<bool> DeleteApplicationById(int id);
    }
}
