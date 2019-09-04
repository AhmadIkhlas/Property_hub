using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVS360
{
    public class City : IListable
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
         
        public string Name { get; set; }

        [Required]
        public virtual Province Province { get; set; }
    }
}
