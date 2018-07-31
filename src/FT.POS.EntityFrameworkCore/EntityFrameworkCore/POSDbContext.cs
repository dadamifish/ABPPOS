using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FT.POS.Authorization.Roles;
using FT.POS.Authorization.Users;
using FT.POS.MultiTenancy;
using System.Collections.Generic;
using FT.POS.POSTests;

namespace FT.POS.EntityFrameworkCore
{
    public class POSDbContext : AbpZeroDbContext<Tenant, Role, User, POSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        

        public DbSet<POSTest> POSTest { get; set; }

        public POSDbContext(DbContextOptions<POSDbContext> options)
            : base(options)
        {
        }
    }
}
