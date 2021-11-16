using SofthouseTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofthouseTask.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
