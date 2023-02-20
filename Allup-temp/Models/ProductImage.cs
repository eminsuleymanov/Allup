using System;
namespace Allup_temp.Models
{
    public class ProductImage:BaseEntity
    {
        public string Image { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

