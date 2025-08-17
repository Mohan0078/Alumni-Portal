using Alumni_Portal.Models.RequestModels;
using Alumni_Portal.Services.Interfaces;
using EntityModels.Models;

namespace Alumni_Portal.Services.Services
{
	public class MemberService : IMemberService
    {
        public async Task<bool> AddMember(AddMemberRequestModel addMemberRequestModel)
        {
			try
			{
				var contactDetails = new ContactDetails()
				{
					ContactDetailsId = Guid.NewGuid(),
					Email = addMemberRequestModel.Email,
					MobileNumber = addMemberRequestModel.MobileNumber,
					//CreatedBy = , Handle this 
					CreatedOn = DateTime.UtcNow
				};

				var member = new Member()
				{
					MemberId = Guid.NewGuid(),
					ContactDetailsId = contactDetails.ContactDetailsId,
					FirstName = addMemberRequestModel.FirstName,
					MiddleName = addMemberRequestModel.MiddleName,
					LastName = addMemberRequestModel.LastName,
					//CreatedBy = , Handle this
					CreatedOn = DateTime.UtcNow
				};

				return true;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
