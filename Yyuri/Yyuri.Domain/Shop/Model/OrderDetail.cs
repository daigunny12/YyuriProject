using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain.Shop.Model
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public Guid OrderID { set; get; }

        [Key]
        [Column(Order = 2)]
        public Guid ProductID { set; get; }

        public int Quantity { set; get; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { set; get; }

        [ForeignKey("ProductID")]
        public virtual ProductCategory ProductCategory { set; get; }

        [ForeignKey("OrderID")]
        public virtual Order Order { set; get; }

    }
}