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
    public class AddPlantLocationsCommand : IRequest<PlantsManagementResponse>
    {
        public string plantId { get; set; }
        public List<PlantLocation> plantLocations { get; set; }

        public class AddPlantLocationsCommandHandler : IRequestHandler<AddPlantLocationsCommand, PlantsManagementResponse>
        {
            private readonly IApplicationDbContext dbContext;

            public AddPlantLocationsCommandHandler(IApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<PlantsManagementResponse> Handle(AddPlantLocationsCommand request, CancellationToken cancellationToken)
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
                    plantLocations = new List<PlantLocation>();

                foreach(var item in request.plantLocations)
                {
                    plantLocations.Add(item);
                }

                plant.Locations = JsonConvert.SerializeObject(plantLocations);

                dbContext.Plants.Update(plant);
                await dbContext.SaveChangesAsync(cancellationToken);

                return new PlantsManagementResponse
                {
                    isSuccessful = true,
                    message = "Successfully added plant locations"
                };

            }
        }
    }
}
