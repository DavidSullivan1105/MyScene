using MyScenes.Contracts;
using MyScenes.Data;
using MyScenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScenes.Services
{
    public class MySceneService :IMySceneService
    {
        private Guid _userId;
        private readonly ApplicationDbContext _ctx;

        public MySceneService(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public bool CreateMyScene(MySceneCreate model)
        {
            var entity =
                new MyScene()
                {
                    UserId = _userId,
                    Artists = model.Artists,
                    Bands = model.Bands,
                    Venues = model.Venues,
                };
            _ctx.MyScenes.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }


    }
}
