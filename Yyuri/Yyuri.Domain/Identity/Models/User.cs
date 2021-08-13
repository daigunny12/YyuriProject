using Yyuri.Domain;
using Yyuri.Domain.Accounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Yyuri.Domain.Identity.Models
{
    [Table("Users")]
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
        public User()
        {
            UserGroups = new HashSet<UserGroup>();
        }
        //[Required]
        [MinLength(8, ErrorMessage = "Username must has least minimum is 8 charated")]
        public override string UserName { get; set; }

        //[Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string UserCode { get; set; }

        public string DeviceUserID { get; set; }
        public string PhotoUrl { set; get; }
        public string Title { get; set; }

        [MaxLength(2)]
        public string Lang { get; set; }
        [MaxLength(2)]
        public string CountryCode { get; set; }
        [MaxLength(8)]
        public string TimezoneCode { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
