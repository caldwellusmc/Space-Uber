using SpaceUber.Data;
using SpaceUber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Services
{
    public class RiderService
    {
        private readonly Guid _userId;

        public RiderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRider(RiderCreate model)
        {
            var entity =
                new Rider()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Destination = model.Destination
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Riders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RiderListItem> GetRiders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Riders
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RiderListItem
                                {
                                    RiderId = e.RiderId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Destination = e.Destination
                                }
                            );

                return query.ToArray();
            }
        }

        public RiderDetail GetRiderById(int riderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Riders
                        .Single(e => e.RiderId == riderId && e.OwnerId == _userId);
                return
                    new RiderDetail
                    {
                        RiderId = entity.RiderId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Destination = entity.Destination
                    };
            }
        }

        public bool UpdateRider(RiderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Riders
                        .Single(e => e.RiderId == model.RiderId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Destination = model.Destination;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
