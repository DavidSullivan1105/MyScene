using MyScene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Contracts
{
    public interface IBandService
    {
         bool CreateBand(BandCreate model);
         IEnumerable<BandListItem> GetBands();
         void SetUserId(Guid userId);
         BandDetail GetBandById(int id);
         bool UpdateBand(BandEdit model);
         bool DeleteBand(int bandId);
    }
}
