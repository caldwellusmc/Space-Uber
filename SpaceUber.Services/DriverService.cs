using SpaceUber.Data;
using SpaceUber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceUber.Services
{
    public class DriverService
    {
        private readonly Guid _userId;

        public DriverService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateDriver(DriverCreate model)
        {
            var entity =
                new Driver()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    LicenseNumber = model.LicenseNumber,
                    SpaceshipMake = model.SpaceshipMake
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Drivers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DriverListItem> GetDrivers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Drivers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new DriverListItem
                                {
                                    DriverId = e.DriverId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Age = e.Age,
                                    LicenseNumber = e.LicenseNumber,
                                    SpaceshipMake = e.SpaceshipMake
                                }
                         );
                return query.ToArray();
            }
        }

        public DriverDetail GetDriverById(int driverId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drivers
                        .Single(e => e.DriverId == driverId && e.OwnerId == _userId);
                return
                    new DriverDetail
                    {
                        DriverId = entity.DriverId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Age = entity.Age,
                        LicenseNumber = entity.LicenseNumber,
                        SpaceshipMake = entity.SpaceshipMake
                    };
            }
        }

        public bool UpdateDriver(DriverEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drivers
                        .Single(e => e.DriverId == model.DriverId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Age = model.Age;
                entity.LicenseNumber = model.LicenseNumber;
                entity.SpaceshipMake = model.SpaceshipMake;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDriver(int driverId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drivers
                        .Single(e => e.DriverId == driverId && e.OwnerId == _userId);

                ctx.Drivers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
