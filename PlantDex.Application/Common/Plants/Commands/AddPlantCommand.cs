using MediatR;
using PlantDex.Application.DTO.PlantsManagement;
using PlantDex.Application.Services;
using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDex.Application.Common.Plants.Commands
{
    public class AddPlantCommand : IRequest<PlantsManagementResponse>
    {

        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public class AddPlantCommandHandler : IRequestHandler<AddPlantCommand, PlantsManagementResponse>
        {
            private readonly IApplicationDbContext dbContext;

            public AddPlantCommandHandler(IApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<PlantsManagementResponse> Handle(AddPlantCommand request, CancellationToken cancellationToken)
            {
                Plant plant = new Plant()
                {
                    CommonName = request.CommonName,
                    Description = request.Description,
                    ScientificName = request.ScientificName,
                    ShortDescription = request.ShortDescription,
                };

                dbContext.Plants.Add(plant);

                await dbContext.SaveChangesAsync(cancellationToken);

                return new PlantsManagementResponse
                {
                    isSuccessful = true,
                    message = $"Successfully added plant `{plant.ScientificName}` !"
                };
            }
        }

    }
}
