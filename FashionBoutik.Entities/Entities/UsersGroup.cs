using System.Collections.Generic;

namespace FashionBoutik.Entities
{
    public class UsersGroup :  BaseEntity<int>
    {
        public string Description { get; set; }

        //[ForeignKey("UsersGroupId")]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
