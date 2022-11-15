using MyScene.Contracts;
using MyScene.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Services
{
    public class BandService : IBandService
    {
        private Guid _userId;
        private readonly ApplicationDbContext _ctx;
        public BandService( ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }
    }
}
