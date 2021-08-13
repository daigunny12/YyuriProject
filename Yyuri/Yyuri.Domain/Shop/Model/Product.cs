using Yyuri.Domain.Shop.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain.Shop.Model
{
    [Table("Products")]
    public class Product : Auditable, IEntity<System.Guid>
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }

        public Guid CategoryID { set; get; }
        [MaxLength(256)]
        public string Image { set; get; }

        [Column(TypeName = "xml")]
        public string MorelImages { set; get; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { set; get; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }
        public string Content { set; get; }

        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        public string Tags { set; get; }

        public int Quantity { set; get; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OriginalPrice { set; get; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { set; get; }

        public virtual IEnumerable<ProductTag> ProductTags { set; get; }
    }
}