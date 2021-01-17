using MediatR;
using Newtonsoft.Json;
using PlantDex.Application.DTO.ContributionsManagement;
using PlantDex.Application.Services;
using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDex.Application.Common.ContributionSubmissions.Commands
{
    public class AddContributionSubmissionCommand : IRequest<ContributionsManagementResponse>
    {
        public string scientificName { get; set; }
        public string commonName { get; set; }
        public string remarks { get; set; }
        public List<PlantLocation> locations { get; set; }

        public class AddContributionSubmissionCommandHandler : IRequestHandler<AddContributionSubmissionCommand, ContributionsManagementResponse>
        {
            private readonly IApplicationDbContext db;

            public AddContributionSubmissionCommandHandler(IApplicationDbContext db)
            {
                this.db = db;
            }
            public async Task<ContributionsManagementResponse> Handle(AddContributionSubmissionCommand request, CancellationToken cancellationToken)
            {
                ContributionSubmission contributionSubmission = new ContributionSubmission()
                {
                    CommonName = request.commonName,
                    ScientificName = request.scientificName,
                    CreatedOn = DateTime.Now,
                    Remarks = request.remarks,
                    Locations = (request == null) ? null : JsonConvert.SerializeObject(request.locations)
                };

                ContributionsManagementResponse contributionsManagementResponse = new ContributionsManagementResponse()
                {
                    isSuccessful = true,
                    message = "Successfully saved contribution"
                };


                db.ContributionSubmissions.Add(contributionSubmission);
                await db.SaveChangesAsync(cancellationToken);
                return contributionsManagementResponse;
            }
        }
    }
}
