using Alumni_Portal.Models.RequestModels;
using Alumni_Portal.Services.Interfaces;
using Alumni_Portal.Services.Utilities;
using EntityModels.Models;

namespace Alumni_Portal.Services.Services
{
	public class MemberService : IMemberService
    {
		private readonly AlumniPortalContext _alumniPortalContext;
		private readonly IUnitOfWork _unitOfWork;

		public MemberService(AlumniPortalContext alumniPortalContext, IUnitOfWork unitOfWork)
		{
			_alumniPortalContext = alumniPortalContext;
			_unitOfWork = unitOfWork;
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

				return await _unitOfWork.CommitTransactionAsync() > 0;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
