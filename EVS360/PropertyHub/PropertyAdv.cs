using EVS360.UsersMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS360.PropertyHub
{
    public class PropertyAdv : IListable
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        public float Price { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime StartsOn { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public virtual PropertyArea Area { get; set; }

        [Required]
        public virtual AdvType AdvType { get; set; }

        [Required]
        public virtual AdvStatus AdvStatus { get; set; }

        [Required]
        public virtual NeighborhoodBlock SchemeBlock { get; set; }

        [Required]
        public virtual User PostedBy { get; set; }

        public virtual ICollection<PropertyImage> Images { get; set; }




    }
}
