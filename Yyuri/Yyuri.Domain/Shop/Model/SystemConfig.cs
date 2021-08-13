using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain.Shop.Model
{
    [Table("SystemConfigs")]
    public class SystemConfig: IEntity<System.Guid>
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        [MaxLength(50)]
        public string Code { set; get; }

        [MaxLength(50)]
        public string ValueString { set; get; }

        public int? ValueInt { set; get; }
    }
}