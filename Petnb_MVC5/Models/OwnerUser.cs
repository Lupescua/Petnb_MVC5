using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Petnb_MVC5.Models
{
    public class OwnerUser 
    {
        public int OwnerUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}