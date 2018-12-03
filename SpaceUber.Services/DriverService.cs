﻿using SpaceUber.Data;
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
    }
}