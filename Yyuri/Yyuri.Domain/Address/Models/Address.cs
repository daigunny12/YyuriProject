using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yyuri.Domain.Address.Models
{
    [Table("Addresses")]
    public class Address : AuditBase, IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(128, ErrorMessage = "StreetNumber cannot be longer than 128 characters.")]
        public string StreetNumber { get; set; }

        [StringLength(500, ErrorMessage = "StreetName cannot be longer than 500 characters.")]
        public string StreetName { get; set; }

        [StringLength(500, ErrorMessage = "StreetName2 cannot be longer than 500 characters.")]
        public string StreetName2 { get; set; }

        public Guid? DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        public Guid? ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        public Guid? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public string CountryCode { get; set; }
    }
}
