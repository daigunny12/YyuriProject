using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain.Shop.Model
{
    [Table("Footers")]
    public class Footer: IEntity<System.Guid>
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        public string Content { set; get; }
    }
}