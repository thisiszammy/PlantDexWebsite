using MediatR;
using Newtonsoft.Json;
using PlantDex.Application.DTO.PlantsManagement;
using PlantDex.Application.Services;
using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDex.Application.Common.Plants.Commands
{
    public class DeletePlantLocationCommand : IRequest<PlantsManagementResponse>
    {
        public string plantId { get; set; }
        public string lng { get; set; }
        public string lat { get; set; }

        public class DeletePlantLocationCommandHandler : IRequestHandler<DeletePlantLocationCommand, PlantsManagementResponse>
        {
            private readonly IApplicationDbContext dbContext;

            public DeletePlantLocationCommandHandler(IApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<PlantsManagementResponse> Handle(DeletePlantLocationCommand request, CancellationToken cancellationToken)
            {
                var plant = dbContext.Plants.Where(x => x.Id == Convert.ToInt32(request.plantId)).FirstOrDefault();

                if (plant == null)
                    return new PlantsManagementResponse
                    {
                        isSuccessful = false,
                        message = "Invalid Plant ID"
                    };

                List<PlantLocation> plantLocations = (plant.Locations == null) ? null : JsonConvert.DeserializeObject<List<PlantLocation>>(plant.Locations);

                if (plantLocations == null)
                    return new PlantsManagementResponse
                    {
                        isSuccessful = false,
                        message = "Plant has no locations"
                    };

                plantLocations.RemoveAll(x => x.Latitude == request.lat && x.Longitude == request.lng);

                plant.Locations = JsonConvert.SerializeObject(plantLocations);

                dbContext.Plants.Update(plant);

                await dbContext.SaveChangesAsync(cancellationToken);

                return new PlantsManagementResponse
                {
                    isSuccessful = true,
                    message = "Successfully deleted location"
                };
            }
        }
    }
}
