using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionBoutik.Entities
{
    /// <summary>
    /// Relational (intermediate) table for many-to-many user <=> groups relationship
    /// </summary>
    public class UserToUsersGroup
    {
        //These fiels are compose key
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int UsersGroupId { get; set; }

        //Relatated entities
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("UsersGroupId")]
        public UsersGroup UsersGroup { get; set; }
    }
}
