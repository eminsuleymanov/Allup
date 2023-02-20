using System;
using System.ComponentModel.DataAnnotations;

namespace Allup_temp.Models
{
    public class Setting
    {

        public int Id { get; set; }
        [StringLength(255)]
        public string Key { get; set; }
        [StringLength(1000)]
        public string Value { get; set; }
    }
}

