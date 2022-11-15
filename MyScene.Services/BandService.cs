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
    public class BandService : IBandService
    {
        private Guid _userId;
        private readonly ApplicationDbContext _ctx;
        public BandService( ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool CreateBand(BandCreate model)
        {
            var entity =
                new Band()
                {
                    OwnerId = _userId,
                    BandName = model.BandName,
                    BandGenre = model.Genre

                };
            _ctx.Bands.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<BandListItem> GetBands()
        {
            var query =
                _ctx
                .Bands
                .Where(e => e.OwnerId == _userId)
                .Select(
                    e =>
                    new BandListItem
                    {
                        BandId = e.BandsId,
                        BandName = e.BandName,
                        Genre = e.BandGenre,

                    });
            return query.ToArray();
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }
    }
}
