﻿using MyScene.Models;
using MyScene.Contracts;
using MyScene.Data;
using MyScene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Services
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
                new MyScene.Data.MyScene()
                {
                    //UserId = _userId,
                    Artists = model.Artists,
                    Bands = model.Bands,
                    Venues = model.Venues,
                };
            _ctx.MyScene.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<MySceneListItem> GetMyScenes()
        {
            var query =
                _ctx
                .MyScenes
                .Where(e => e.UserId == _userId)
                .Select(
                    e =>
                    new MySceneListItem
                    {
                        UserId = e.UserId,
                        Artists = e.Artists,
                        Bands = e.Bands,
                        Venues = e.Venues,
                    });
            return query.ToArray();
        }

        public MySceneDetail GetMySceneById(Guid userId)
        {
            var entity =
                _ctx
                .MyScenes
                .Single(e => e.UserId == userId);

            return
                new MySceneDetail
                {
                    UserId = userId,
                    Artists = entity.Artists,
                    Bands = entity.Bands,
                    Venues = entity.Venues,
                };
        }


        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }


    }
}
