using System;
using System.Collections.Generic;

namespace EntityModels.Models
{
    public partial class Address
    {
        public Guid AddressId { get; set; }
        public string StreetAddress { get; set; } = null!;
        public Guid CityId { get; set; }
        public Guid StateId { get; set; }
        public string ZipCode { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
