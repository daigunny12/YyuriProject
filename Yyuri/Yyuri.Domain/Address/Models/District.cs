using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yyuri.Domain.Identity.Models;

namespace Yyuri.Domain.Address
{
    [Table("Districts")]
    public class District : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(500, ErrorMessage = "Name cannot be longer than 500 characters.")]
        public string Name { get; set; }

        public string ProvinceCode { get; set; }
    }
}
