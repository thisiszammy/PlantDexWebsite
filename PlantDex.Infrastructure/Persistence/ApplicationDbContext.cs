using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlantDex.Application.Services;
using PlantDex.Domain.Common;
using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDex.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>,IApplicationDbContext
    {
        private readonly ICurrentUserService currentUserService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            this.currentUserService = currentUserService;
        }

        public DbSet<Plant> plants { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            //foreach (var item in ChangeTracker.Entries<AuditableEntity>())
            //{
            //    switch (item.State)
            //    {
            //        case EntityState.Added:
            //            {
            //                item.Entity.CreatedBy = currentUserService.currentUserId;
            //                item.Entity.CreatedOn = dateTimeService.currentDateTime;
            //                break;
            //            }
            //        case EntityState.Modified:
            //            {
            //                item.Entity.LastModifiedBy = currentUserService.currentUserId;
            //                item.Entity.LastModifiedOn = dateTimeService.currentDateTime;
            //                break;
            //            }
            //    }
            //}
            return base.SaveChangesAsync(cancellationToken);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
