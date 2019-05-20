using Petnb_MVC5.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Petnb_MVC5.Models
{
    public class PetType
    {
        public int PetTypeId { get; set; }
        public PetTypeEnum PetTypeEnum { get; set; }
        public List<PetSitterOfferPetTypeModel> PetSitterOfferPetTypeModels { get; set; }
    }
}