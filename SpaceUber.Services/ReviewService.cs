﻿using SpaceUber.Data;
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
                    //FirstName = model.FirstName,
                    //LastName = model.LastName,
                    Description = model.Description,
                    DriverId= model.DriverId
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
                                FirstName = e.Driver.FirstName,
                                LastName = e.Driver.LastName,
                                Description = e.Description
                            }
                        );

                return query.ToArray();
            }
        }

        public ReviewDetail GetReviewById(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);
                return
                    new ReviewDetail
                    {
                        ReviewId = entity.ReviewId,
                        FirstName = entity.Driver.FirstName,
                        LastName = entity.Driver.LastName,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == model.ReviewId && e.OwnerId == _userId);

               // entity.FirstName = model.FirstName;
                //entity.LastName = model.LastName;
                entity.Description = model.Description;
                entity.DriverId = model.DriverId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public List<Driver> Drivers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Drivers.ToList();
            }
        }
    }
}
