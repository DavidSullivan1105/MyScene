using MyScene.Data;
using MyScene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyScene.Services
{
    public class ArtistService : IArtistService
    {
        private Guid _userId;
        private readonly ApplicationDbContext _ctx;
        public ArtistService(ApplicationDbContext context)
        {
            _ctx = context;
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

            {
                _ctx.Artists.Add(entity);
                return _ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistListItem> GetArtist()
        {

            var query =
               _ctx
                    .Artists
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ArtistListItem
                        {
                            ArtistId = e.ArtistId,
                            ArtistName = e.ArtistName,
                            ArtistEmail = e.ArtistEmail,
                            ArtistPhone = e.ArtistPhone,
                            //Band = e.Band,
                            Instrument = e.Instrument,
                        });
            return query.ToArray();

        }

        public ArtistDetail GetArtistById(int id)
        {


            var entity =
                _ctx
                    .Artists
                    .Single(e => e.ArtistId == id && e.OwnerId == _userId);
            return
                new ArtistDetail
                {
                    ArtistId = entity.ArtistId,
                    ArtistName = entity.ArtistName,
                    ArtistPhone = entity.ArtistPhone,
                    ArtistEmail = entity.ArtistEmail,
                    Instrument = entity.Instrument,
                    
                };
        }

        public bool UpdateArtist(ArtistEdit model)
        {
            var entity=
                _ctx
                .Artists.Single(e => e.ArtistId == model.ArtistId && e.OwnerId == _userId);

            entity.ArtistId = model.ArtistId;
            entity.ArtistName = model.ArtistName;
            entity.ArtistEmail = model.ArtistEmail;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteArtist(int artistId)
        {
            var entity =
                _ctx
                .Artists
                .Single(e => e.ArtistId == artistId && e.OwnerId == _userId);

            _ctx.Artists.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }
    }
}




    

