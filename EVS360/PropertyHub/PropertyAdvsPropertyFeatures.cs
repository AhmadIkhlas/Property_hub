using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EVS360.PropertyHub
{
    public class PropertyAdvsPropertyFeatures
    {
        public int Id { get; set; }

        [Required]
        public virtual PropertyAdv Advertisement { get; set; }

        [Required]
        public virtual PropertyFeature Feature { get; set; }
    }
}
