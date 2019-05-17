using Petnb_MVC5.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Petnb_MVC5.Models
{   
    public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public PetType PetType { get; set; }
        public int PetAge { get; set; }
        public double PetDifficulty { get; set; }
        public double PetWeight { get; set; }
        public string PetBreed { get; set; }

        public string OwnerUserId { get; set; }
        public OwnerUser OwnerUser { get; set; }

        public List<PetOffer> PetOffers { get; set; } = new List<PetOffer>();
    }
}