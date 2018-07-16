
using System;
using Microsoft.AspNetCore.Identity;

namespace FashionBoutik.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
