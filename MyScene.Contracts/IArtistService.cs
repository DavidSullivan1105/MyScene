using MyScene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Services
{
    public interface IArtistService
    {
         bool CreateArtist(ArtistCreate model);
         IEnumerable<ArtistListItem> GetArtist();
         ArtistDetail GetArtistById(int id);
         void SetUserId(Guid userId);
         bool UpdateArtist(ArtistEdit model);
         bool DeleteArtist(int artistId);

    }
}
