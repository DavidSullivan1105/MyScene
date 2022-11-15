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
        public bool CreateBand(BandCreate model);
        public IEnumerable<BandListItem> GetBands();
        public void SetUserId(Guid userId);
    }
}
