using MyScenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScenes.Contracts
{
    public interface IBandService
    {
        public bool CreateBand(BandCreate model);
        public IEnumerable<BandListItem> GetBands();
        public void SetUserId(Guid userId);
        public BandDetail GetBandById(int id);
        public bool UpdateBand(BandEdit model);
        public bool DeleteBand(int bandId);
    }
}
