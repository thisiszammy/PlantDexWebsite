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
    public class GetPlantByCommonNameQuery : IRequest<PlantsManagementResponse>
    {
        public string CommonName { get; set; }

        public class GetPlantByCommonNameQueryHandler : IRequestHandler<GetPlantByCommonNameQuery, PlantsManagementResponse>
        {
            private readonly IApplicationDbContext dbContext;

            public GetPlantByCommonNameQueryHandler(IApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public Task<PlantsManagementResponse> Handle(GetPlantByCommonNameQuery request, CancellationToken cancellationToken)
            {
                var plants = dbContext.Plants.Where(x => x.CommonName.Contains(request.CommonName) || request.CommonName.Contains(x.CommonName)).ToList();

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
