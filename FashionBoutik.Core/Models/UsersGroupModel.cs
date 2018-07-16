
using FashionBoutik.Entities;
using System.Collections.Generic;

namespace FashionBoutik.Models
{
    public class UsersGroupModel
    {
        public int Id { get; set; }

        //public int? ParentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

        //public ICollection<UserModel> Users { get; set; } = new List<UserModel>();
    }
}