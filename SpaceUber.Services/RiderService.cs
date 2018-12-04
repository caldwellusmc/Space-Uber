﻿using SpaceUber.Data;
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
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Destination = e.Destination
                                }
                            );

                return query.ToArray();
            }
        }
    }
}
