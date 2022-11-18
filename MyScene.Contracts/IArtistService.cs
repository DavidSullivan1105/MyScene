using MyScenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScenes.Services
{
    public interface IArtistService
    {
        public bool CreateArtist(ArtistCreate model);
        public IEnumerable<ArtistListItem> GetArtist();
        public ArtistDetail GetArtistById(int id);
        public void SetUserId(Guid userId);
        public bool UpdateArtist(ArtistEdit model);
        public bool DeleteArtist(int artistId);

    }
}
