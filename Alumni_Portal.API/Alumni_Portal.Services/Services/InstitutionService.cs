using Alumni_Portal.Models.RequestModels;
using Alumni_Portal.Models.ResponseModel;
using Alumni_Portal.Services.Interfaces;
using Alumni_Portal.Services.Utilities;
using EntityModels.Models;

namespace Alumni_Portal.Services.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly AlumniPortalContext _alumniPortalContext;
        private readonly IUnitOfWork _unitOfWork;

        public InstitutionService(AlumniPortalContext alumniPortalContext, IUnitOfWork unitOfWork)
        {
            _alumniPortalContext = alumniPortalContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<InstitutionResponseModel> GetAllInstitutions()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveInstitution(InstitutionRequestModel institutionRequestModel)
        {
            try
            {
                var institutionsDBSet = _alumniPortalContext.Institutions;

                var institution = new Institution()
                {
                    Id = Guid.NewGuid(),
                    Name = institutionRequestModel.Name,
                    Address = institutionRequestModel.Address,
                    City = institutionRequestModel.City,
                    Code = institutionRequestModel.Code,
                    Country = institutionRequestModel.Country,
                    CreatedAt = DateTime.Now,
                    Email = institutionRequestModel.Email,
                    EstablishedYear = institutionRequestModel.EstablishedYear,
                    Logo = institutionRequestModel.Logo,
                    Phone = institutionRequestModel.Phone,
                    State = institutionRequestModel.State,
                    Status = institutionRequestModel.Status,
                    Website = institutionRequestModel.Website,
                };

                institutionsDBSet.Add(institution);
               
                return await _unitOfWork.CommitTransactionAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
