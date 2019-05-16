using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Petnb_MVC5.Models
{
    public class PetOffer
    {
        public int PetOfferId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public decimal? Reward { get; set; }
        public string PetLocation { get; set; }
        public string PetNeeds { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartOfSit { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndOfSit { get; set; }
        //The user is not the owner is the sitter

        public string PetId { get; set; }
        public Pet Pet { get; set; }

        public string SitterUserId { get; set; }
        public ApplicationUser SitterUser { get; set; }

    }
}