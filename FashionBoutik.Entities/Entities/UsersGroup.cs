using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionBoutik.Entities
{
    public class UsersGroup :  BaseEntity<int>
    {
        public string Description { get; set; }

        [ForeignKey("UsersGroupId")]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
