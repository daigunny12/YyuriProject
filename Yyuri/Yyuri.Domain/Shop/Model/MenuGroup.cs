using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain.Shop.Model
{
    [Table("MenuGroups")]
    public class MenuGroup: IEntity<System.Guid>
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        [MaxLength(250)]
        public string Name { set; get; }
        public virtual IEnumerable<Menu> Menus { set; get; }
    }
}