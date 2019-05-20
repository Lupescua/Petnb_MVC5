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
        public PetTypeEnum PetTypeEnum { get; set; }
        public int PetAge { get; set; }
        //We initially intended to allow sitters to grade the animal's difficulty. Nice to have
        public double PetDifficulty { get; set; }
        public double PetWeight { get; set; }
        public string PetBreed { get; set; }

        public string OwnerUserId { get; set; }
        public OwnerUser OwnerUser { get; set; }

        public List<PetOffer> PetOffers { get; set; } = new List<PetOffer>();
    }
}