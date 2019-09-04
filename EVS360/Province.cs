using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EVS360
{
    public class Province : IListable
    {
        public Province()
        {
            Cities = new List<City>();
        }

        public int Id { get; set; }

        [Required]         
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }

    }
}
