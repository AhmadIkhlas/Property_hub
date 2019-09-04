using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS360.UsersMgt
{
    public class User : IListable
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string LoginId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string ContactNumber { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string ImageUrl { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string SecurityQuestion { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string SecurityAnswer { get; set; }
        public virtual Address Address { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        public bool IsInRole(int id)
        {
            return Role != null && Role.Id == id;
        }

    }
}

