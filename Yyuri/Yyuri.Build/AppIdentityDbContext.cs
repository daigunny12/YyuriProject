using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Yyuri.Domain.Identity.Models;
using Yyuri.Domain.Accounts.Models;
using Yyuri.Data.EntityFramework;

namespace Yyuri.Build
{
    public class AppIdentityDbContext : SCDataContext
    {
        public AppIdentityDbContext(DbContextOptions<SCDataContext> options) : base(options, null)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
