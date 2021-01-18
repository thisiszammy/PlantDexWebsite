using MediatR;
using PlantDex.Application.DTO.ComplaintsManagement;
using PlantDex.Application.Services;
using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDex.Application.Common.SubmittedComplaints.Commands
{
    public class AddSubmittedComplaintCommand : IRequest<ComplaintsManagementResponse>
    {

        public string userId { get; set; }
        public string appVersion { get; set; }
        public string phoneVersion { get; set; }
        public string remarks { get; set; }

        public class AddSubmittedComplaintCommandHandler : IRequestHandler<AddSubmittedComplaintCommand, ComplaintsManagementResponse>
        {
            private readonly IApplicationDbContext db;

            public AddSubmittedComplaintCommandHandler(IApplicationDbContext db)
            {
                this.db = db;
            }

            public async Task<ComplaintsManagementResponse> Handle(AddSubmittedComplaintCommand request, CancellationToken cancellationToken)
            {
                if (request == null)
                    return new ComplaintsManagementResponse()
                    {
                        isSuccessful = false,
                        message = "Invalid Parameters"
                    };

                SubmittedComplaint complaints = new SubmittedComplaint()
                {
                    appVersion = request.appVersion,
                    remarks = request.remarks,
                    userId = request.userId,
                    phoneVersion = request.phoneVersion
                };


                db.SubmittedComplaints.Add(complaints);
                await db.SaveChangesAsync(cancellationToken);

                return new ComplaintsManagementResponse()
                {
                    isSuccessful = true,
                    message = "Successfully Filed Complaint"
                };
            }
        }

    }
}
