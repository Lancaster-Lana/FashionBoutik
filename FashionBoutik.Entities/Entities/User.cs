using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FashionBoutik.Entities
{
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// First name + Last name
        /// </summary>
        public string Name { get; set; }

        //[ForeignKey("UsersGroupId")]
        public virtual ICollection<UsersGroup> UsersGroups { get; set; } = new List<UsersGroup>();
    }
}
