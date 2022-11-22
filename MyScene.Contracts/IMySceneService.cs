using MyScene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScene.Contracts
{
    public interface IMySceneService
    {
        void SetUserId(Guid userId);
        bool CreateMyScene(MySceneCreate model);
        IEnumerable<MySceneListItem> GetMyScenes();
        MySceneDetail GetMySceneById(Guid userId);
        bool UpdateMyScene(MySceneEdit model);
        bool DeleteMyScene(Guid userId);
    }
}
