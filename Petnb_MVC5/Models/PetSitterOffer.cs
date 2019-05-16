using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Petnb_MVC5.Models
{
    public class PetSitterOffer
    {
        public int PetSitterOfferId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public DateTime StartOfSit { get; set; }
        public DateTime EndOfSit { get; set; }
        public int ExpectedSalary { get; set; }
        public ApplicationUser SitterUser { get; set; }

        public string OwnerUserId { get; set; }
        public ApplicationUser OwnerUser { get; set; }

    }
}