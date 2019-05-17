using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Petnb_MVC5.Models
{
    public class SitterUser
    {
        public int SitterUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<PetSitterOffer> PetSitterOffers { get; set; } = new List<PetSitterOffer>();
    }
}