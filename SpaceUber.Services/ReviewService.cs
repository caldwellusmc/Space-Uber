using SpaceUber.Data;
using SpaceUber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Description = model.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new ReviewListItem
                            {
                                ReviewId = e.ReviewId,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Description = e.Description
                            }
                        );

                return query.ToArray();
            }
        }
    }
}
