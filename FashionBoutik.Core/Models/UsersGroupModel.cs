
using FashionBoutik.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FashionBoutik.Models
{
    public class UsersGroupModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}