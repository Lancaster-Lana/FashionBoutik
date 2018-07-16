using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionBoutik.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public int? UsersGroupId { get; set; }

        [ForeignKey("UsersGroupId")]
        public virtual UsersGroup UsersGroup { get; set; }
    }
}
