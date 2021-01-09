using MediatR;
using PlantDex.Application.DTO.PlantsManagement;
using PlantDex.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDex.Application.Common.Plants.Queries
{
    public class GetPlantByScientificNameQuery : IRequest<PlantsManagementResponse>
    {
        public string ScientificName { get; set; }

        public class GetPlantByScientificNameQueryHandler : IRequestHandler<GetPlantByScientificNameQuery, PlantsManagementResponse>
        {
            private readonly IApplicationDbContext dbContext;

            public GetPlantByScientificNameQueryHandler(IApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<PlantsManagementResponse> Handle(GetPlantByScientificNameQuery request, CancellationToken cancellationToken)
            {
                var plants = dbContext.Plants.Where(x => x.ScientificName.Contains(request.ScientificName) ||
                request.ScientificName.Contains(x.ScientificName)).ToList();

                return Task.FromResult(new PlantsManagementResponse
                {
                    isSuccessful = true,
                    message = "Successfully retrieved plants",
                    plants = plants
                });
            }
        }
    }
}
