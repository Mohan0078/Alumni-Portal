using Alumni_Portal.Models.RequestModels;
using Alumni_Portal.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumni_Portal.Services.Interfaces
{
    public interface IInstitutionService
    {
        Task<bool> SaveInstitution(InstitutionRequestModel institutionRequestModel);
        Task<InstitutionResponseModel> GetAllInstitutions();
    }
}
