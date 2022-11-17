﻿using MyScene.Contracts;
using MyScene.Data;
using MyScene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Services
{
    public class VenueService : IVenueService
    {
        private Guid _userId;
        private readonly ApplicationDbContext _ctx;

        public VenueService(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public bool CreateVenue(VenueCreate model)
        {
            var entity =
                new Venue()
                {
                    VenueID = model.VenueId,
                    VenueName = model.VenueName,
                    VenueAddress = model.VenueAddress,
                    VenuePhone = model.VenuePhone,
                    Is21AndOver = model.Is21AndOver,
                };
            
            _ctx.Venues.Add(entity);
            return _ctx.SaveChanges() == 1;
            
        }

        public IEnumerable<VenueListItem> GetVenues()
        {
            var query =
                _ctx
                .Venues
                .Where(e => e.OwnerId == _userId)
                .Select(
                    e =>
                    new VenueListItem
                    {
                        VenueId = e.VenueID,
                        VenueName = e.VenueName,
                        VenueAddress = e.VenueAddress,
                        VenuePhone = e.VenuePhone,
                        Is21AndOver = e.Is21AndOver,
                    });
            return query.ToArray();
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }

    }



}
