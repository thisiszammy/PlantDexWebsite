using MediatR;
using PlantDex.Application.DTO.PlantsManagement;
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
    public class GetPlantByIdQuery : IRequest<PlantsManagementResponse>
    {
        public string Id { get; set; }

        public class GetPlantByIdQueryHandler : IRequestHandler<GetPlantByIdQuery, PlantsManagementResponse>
        {
            private readonly IApplicationDbContext dbContext;

            public GetPlantByIdQueryHandler(IApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<PlantsManagementResponse> Handle(GetPlantByIdQuery request, CancellationToken cancellationToken)
            {
                var plant = dbContext.Plants.Where(x => x.Id == Convert.ToInt32(request.Id)).ToList();

                return Task.FromResult(new PlantsManagementResponse
                {
                    isSuccessful = true,
                    message = "Successfully retrieved plants",
                    plants = plant
                });
            }
        }
    }
}
