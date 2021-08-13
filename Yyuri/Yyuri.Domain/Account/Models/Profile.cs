using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yyuri.Domain.Identity.Models;

namespace Yyuri.Domain.Accounts.Models
{
    [Table("Profiles")]
    public class Profile : IEntity<System.Guid>
    {
        public Profile()
        {
            this.IsDeleted = false;
        }

        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }

        public DateTime? DOB { get; set; }
        public bool Gender { get; set; }

        public byte[] Avatar { get; set; }
        public string AvatarUrl { get; set; }

        [MaxLength(2)]
        public string Lang { get; set; }
        [MaxLength(2)]
        public string CountryCode { get; set; }
        [MaxLength(8)]
        public string TimezoneCode { get; set; }

        public DateTime? StartDate { get; set; }
        public System.DateTime? ResignationDate { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? ProbationDate { get; set; }
        public bool IsFulltime { get; set; }
        public bool IsDeleted { get; set; }
        public string AdditionalPhone { get; set; }
        public string AdditionalEmail { get; set; }      
        public string Address { get; set; }
        public string Skype { get; set; }
        public PROFILE_TYPE ProfileType { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
