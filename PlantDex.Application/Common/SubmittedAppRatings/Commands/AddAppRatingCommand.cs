using MediatR;
using PlantDex.Application.DTO.AppRatingManagement;
using PlantDex.Application.Services;
using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDex.Application.Common.AppRatings.Commands
{
    public class AddAppRatingCommand : IRequest<AppRatingsManagementResponse>
    {
        public string userId { get; set; }
        public int rating { get; set; }

        public class AddAppRatingCommandHandler : IRequestHandler<AddAppRatingCommand, AppRatingsManagementResponse>
        {
            private readonly IApplicationDbContext db;

            public AddAppRatingCommandHandler(IApplicationDbContext db)
            {
                this.db = db;
            }

            public async Task<AppRatingsManagementResponse> Handle(AddAppRatingCommand request, CancellationToken cancellationToken)
            {

                SubmittedAppRating rating = new SubmittedAppRating()
                {
                    userId = request.userId,
                    rating = request.rating
                };

                if (db.SubmittedAppRatings.Any(x => x.userId == request.userId))
                    return (new AppRatingsManagementResponse()
                    {
                        isSuccessful = false,
                        message = "User has already submitted a rating"
                    });

                db.SubmittedAppRatings.Add(rating);

                await db.SaveChangesAsync(cancellationToken);

                return (new AppRatingsManagementResponse()
                {
                    isSuccessful = true,
                    message = "Successfully Submitted Rating"
                });
            }
        }
    }
}
