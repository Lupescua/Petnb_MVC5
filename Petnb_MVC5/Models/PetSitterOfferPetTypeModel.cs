using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Petnb_MVC5.Models
{
    public class PetSitterOfferPetTypeModel
    {
        public int PetSitterOfferId { get; set; }
        public PetSitterOffer PetSitterOffer { get; set; }
        public int PetTypeId { get; set; }
        public PetType PetTypeModel { get; set; }
    }
}