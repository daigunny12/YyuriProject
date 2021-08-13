using Yyuri.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yyuri.Domain.Identity.Models
{
    [Table("RoleClaims")]
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
    }
}
