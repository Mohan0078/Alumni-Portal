using Alumni_Portal.Models.RequestModels;
using Alumni_Portal.Services.Interfaces;
using EntityModels.Models;

namespace Alumni_Portal.Services.Services
{
	public class MemberService : IMemberService
    {
		private readonly AlumniPortalContext _alumniPortalContext;

		public MemberService(AlumniPortalContext alumniPortalContext)
		{
			_alumniPortalContext = alumniPortalContext;
		}

		public async Task<bool> AddMember(AddMemberRequestModel addMemberRequestModel)
        {
			try
			{
				var contactDetailsDBSet = _alumniPortalContext.ContactDetails;
				var memberDBSet = _alumniPortalContext.Members;

                var contactDetails = new ContactDetails()
				{
					ContactDetailsId = Guid.NewGuid(),
					Email = addMemberRequestModel.Email,
					MobileNumber = addMemberRequestModel.MobileNumber,
					//CreatedBy = , Handle this 
					CreatedOn = DateTime.UtcNow
				};

				contactDetailsDBSet.Add(contactDetails);

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

				memberDBSet.Add(member);

				return true;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
