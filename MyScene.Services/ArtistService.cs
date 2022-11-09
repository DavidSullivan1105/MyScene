using MyScene.Data;
using MyScene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Services
{
    public class ArtistService
    {
        private readonly Guid _userId;

        public ArtistService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateArtist(ArtistCreate model)
        {
            var entity = new Artist()
            {
                OwnerId = _userId,
                ArtistName = model.ArtistName,
                ArtistPhone = model.ArtistPhone,
                ArtistEmail = model.ArtistEmail,
                Instrument = model.Instrument,
                
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artist.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistListItem> GetArtist()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artist
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new ArtistListItem
                            {
                                ArtistId = e.ArtistId,
                                ArtistName = e.ArtistName,
                                ArtistEmail = e.ArtistEmail,
                                ArtistPhone = e.ArtistPhone,
                                Band = e.Band,
                                Instrument = e.Instrument,
                            });
                return query.ToArray();
            }
        }

        public ArtistDetail GetArtistById(int id)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artist
                        .Single(e => e.ArtistId == id && e.OwnerId == _userId);
                return
                    new ArtistDetail
                    {
                        ArtistId = entity.ArtistId,
                        ArtistName = entity.ArtistName,
                        ArtistPhone = entity.ArtistPhone,
                        ArtistEmail = entity.ArtistEmail,
                        Instrument = entity.Instrument,
                        Bands = entity.Bands,
                    };
            }
        }




    }
}
