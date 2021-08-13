using Yyuri.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yyuri.Domain.Identity.Models
{
    [Table("Roles")]
    public class Role : IdentityRole<Guid>, IEntity<Guid>
    {
        public Role()
        {
            GroupRoles = new HashSet<GroupRole>();
            UserRoles = new HashSet<UserRole>();
        }
       

        public virtual ICollection<GroupRole> GroupRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
