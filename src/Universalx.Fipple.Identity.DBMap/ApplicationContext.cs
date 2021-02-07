using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Universalx.Fipple.Identity.DBMap.Entities;

namespace Universalx.Fipple.Identity.DBMap
{
    public class ApplicationContext : IdentityDbContext<Users, Roles, Guid>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
