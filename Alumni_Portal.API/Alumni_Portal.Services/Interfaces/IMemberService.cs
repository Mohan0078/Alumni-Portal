using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumni_Portal.Services.Interfaces
{
    public interface IMemberService
    {
        Task<bool> AddMember();
    }
}
