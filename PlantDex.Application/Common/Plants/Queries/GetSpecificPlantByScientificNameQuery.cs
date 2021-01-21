using MediatR;
using PlantDex.Application.Services;
using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDex.Application.Common.Plants.Queries
{
    public class GetSpecificPlantByScientificNameQuery : IRequest<Domain.Entities.Plant>
    {
        public string ScientificName { get; set; }

        public class GetSpecificPlantByScientificNameQueryHandler : IRequestHandler<GetSpecificPlantByScientificNameQuery, Domain.Entities.Plant>
        {
            private readonly IApplicationDbContext dbContext;

            public GetSpecificPlantByScientificNameQueryHandler(IApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }


            public Task<Plant> Handle(GetSpecificPlantByScientificNameQuery request, CancellationToken cancellationToken)
            {
                var plant = dbContext.Plants.Where(x => x.ScientificName == request.ScientificName).FirstOrDefault();
                return Task.FromResult(plant);
            }
        }
    }
}
