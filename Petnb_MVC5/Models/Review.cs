namespace Petnb_MVC5.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Review
    {
        //properties
        public int ReviewId { get; set; }

        public string SitterUserId { get; set; }
        public List<SitterUser> SitterUser { get; set; } = new List<SitterUser>();
        public string OwnerUserId { get; set; }
        public List<OwnerUser> OwnerUser { get; set; } = new List<OwnerUser>();

        public string Heading { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public DateTime DateGiven { get; set; }
    }
}