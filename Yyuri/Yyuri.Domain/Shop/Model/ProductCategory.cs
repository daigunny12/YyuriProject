using Yyuri.Domain.Shop.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain.Shop.Model
{
    [Table("ProductCategory")]
    public class ProductCategory : Auditable, IEntity<System.Guid>
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }

        public string DesCription { set; get; }
        public int? ParentId { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }

        public bool? HomeFlag { set; get; }

        public virtual IEnumerable<Product> Products { set; get; }

        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }
    }
}