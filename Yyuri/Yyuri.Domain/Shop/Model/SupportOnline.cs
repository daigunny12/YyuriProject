using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain.Shop.Model
{
    [Table("SupportOnlines")]
    public class SupportOnline: IEntity<System.Guid>
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        [MaxLength(50)]
        public string Name { set; get; }

        [MaxLength(50)]
        public string Department { set; get; }

        [MaxLength(50)]
        public string Skype { set; get; }

        [MaxLength(50)]
        public string Mobile { set; get; }

        [MaxLength(50)]
        public string Email { set; get; }

        [MaxLength(50)]
        public string Yahoo { set; get; }

        [MaxLength(50)]
        public string Facebook { set; get; }

        public bool Status { set; get; }

        public int? DisplayOrder { set; get; }
    }
}