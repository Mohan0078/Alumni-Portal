using Alumni_Portal.Models.RequestModels;

namespace Alumni_Portal.Services.Interfaces
{
    public interface IMemberService
    {
        Task<bool> AddMember(AddMemberRequestModel addMemberRequestModel);
    }
}
