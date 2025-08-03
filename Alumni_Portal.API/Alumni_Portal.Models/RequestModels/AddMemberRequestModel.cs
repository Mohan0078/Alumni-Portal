using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumni_Portal.Models.RequestModels
{
    public class AddMemberRequestModel
    {
      public string FirstName { get; set; }
      public string MiddleName { get; set; }
      public string LastName { get; set; }
      public string Gender { get; set; }
      public string Email { get; set; }
    }
}
