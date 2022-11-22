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
         void SetUserId(Guid userId);
         bool CreateVenue(VenueCreate model);
         IEnumerable<VenueListItem> GetVenues();
         VenueDetail GetVenueById(int id);
         bool UpdateVenue(VenueEdit model);
         public bool DeleteVenue(int venueId);
    }
}
