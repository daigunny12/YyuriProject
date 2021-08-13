using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yyuri.Domain.Shop.Model
{
    [Table("Orders")]
    public class Order: IEntity<System.Guid>
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        [MaxLength(250)]
        public string CustomerName { set; get; }
        [Required]
        [MaxLength(250)]
        public string CustomerAddress { set; get; }
        [Required]
        [MaxLength(250)]
        public string CustomerEmail { set; get; }
        [Required]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }
        [MaxLength(250)]
        public string CustomerMessage { set; get; }

        public DateTime? CreatedDate { set; get; }

        [MaxLength(50)]
        public string CreatedBy { set; get; }

        [MaxLength(250)]
        public string PaymentMethod { set; get; }

        [Required]
        [MaxLength(50)]
        public string PaymentStatus { set; get; }

        public bool Status { set; get; }
        //[StringLength(128)]
        //[Column(TypeName = "nvarchar")]
        //public string CustomerId { set; get; }

        //[ForeignKey("CustomerId")]
        //public virtual ApplicationUser User { set; get; }

        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }
    }
}
