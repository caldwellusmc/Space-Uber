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
    }
}
