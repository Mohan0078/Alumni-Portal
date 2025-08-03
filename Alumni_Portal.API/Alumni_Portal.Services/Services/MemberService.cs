using Alumni_Portal.Models.RequestModels;
using Alumni_Portal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumni_Portal.Services.Services
{
    public class MemberService : IMemberService
    {
        public async Task<bool> AddMember(AddMemberRequestModel addMemberRequestModel)
        {
			try
			{

				return true;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
