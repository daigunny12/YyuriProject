using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yyuri.Domain.Address
{
    [Table("Provinces")]
    public class Province : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(32, ErrorMessage = "ProvinceCode cannot be longer than 32 characters.")]
        public string ProvinceCode { get; set; }

        [StringLength(500, ErrorMessage = "Name cannot be longer than 500 characters.")]
        public string Name { get; set; }

        public string CountryCode { get; set; }

    }
}
