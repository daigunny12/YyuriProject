using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yyuri.Domain.Identity.Models
{
    [Table("UserLogins")]
    public class UserLogin : IdentityUserLogin<Guid>
    {
    }
}
