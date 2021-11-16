using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SofthouseTask.Data.Context;
using SofthouseTask.Data.Models;
using SofthouseTask.Interfaces;
using SofthouseTask.Models.Request;
using SofthouseTask.Models.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofthouseTask.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<JobApplicationService> _logger;

        public JobApplicationService(AppDbContext context, ILogger<JobApplicationService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> AddApplicationAsync(JobApplicationDTO payload)
        {
            try
            {
                byte[] file = null;
                using (var target = new MemoryStream())
                {
                    payload.CV.CopyTo(target);
                    file = target.ToArray();
                }
                var jobApplication = new JobApplication
                {
                    FirstName = payload.FirstName,
                    LastName = payload.LastName,
                    CV = file,
                    Phone = payload.Phone,
                    Email = payload.Email,
                    IsDeleted=false
                };
                await _context.JobApplication.AddAsync(jobApplication); 
                return await _context.SaveChangesAsync() >= 0;
            }   
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteApplicationById(int id)
        {
            try
            {
                var result = await _context.JobApplication.SingleOrDefaultAsync(j => j.Id == id);
                if(result == null)
                {
                    return false;
                }
                result.IsDeleted = true;
                return await _context.SaveChangesAsync() >= 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        public async Task<byte[]> GetApplicationCvAsync(int id)
        {
            try
            {
                var cv = await _context.JobApplication
                    .Where(j => j.Id == id && j.IsDeleted==false)
                    .Select(j => j.CV)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return cv;                    
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<JobApplicationInfoDTO>> GetApplicationsAsync()
        {
            try
            {
                var result = await _context
                    .JobApplication
                    .Where(j => j.IsDeleted == false)
                    .Select(j=> new JobApplicationInfoDTO
                    {   
                        Id = j.Id,
                        FirstName = j.FirstName, 
                        LastName = j.LastName, 
                        Phone = j.Phone, 
                        Email = j.Email, 
                        
                    })
                    .AsNoTracking()
                    .ToListAsync();
               
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
