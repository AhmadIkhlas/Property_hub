using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVS360
{
    public class Country : IListable
    {
        public Country()
        {
            Provinces = new List<Province>();
        }

        public int Id { get; set; }
        
        public int? Code { get; set; }

        [Required]
        [Column(TypeName="varchar(50)")]         
        public string Name { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
    }
}
