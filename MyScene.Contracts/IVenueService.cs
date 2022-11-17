using MyScene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Contracts
{
    public interface IVenueService
    {
        public void SetUserId(Guid userId);
        public bool CreateVenue(VenueCreate model);
        public IEnumerable<VenueListItem> GetVenues();
        public VenueDetail GetVenueById(int id);
    }
}
