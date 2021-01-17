using Microsoft.EntityFrameworkCore;
using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDex.Application.Services
{
    public interface IApplicationDbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<ContributionSubmission> ContributionSubmissions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
