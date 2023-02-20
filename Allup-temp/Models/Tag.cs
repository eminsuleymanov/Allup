using System;
using System.ComponentModel.DataAnnotations;

namespace Allup_temp.Models
{
    public class Tag:BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }
    }
}

