using MyScenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScenes.Contracts
{
    public interface IVenueService
    {
        public void SetUserId(Guid userId);
        public bool CreateVenue(VenueCreate model);
        public IEnumerable<VenueListItem> GetVenues();
        public VenueDetail GetVenueById(int id);
        public bool UpdateVenue(VenueEdit model);
        public bool DeleteVenue(int venueId);
    }
}
