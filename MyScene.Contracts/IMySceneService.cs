using MyScene.Models;
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
        public void SetUserId(Guid userId);
        public bool CreateMyScene(MySceneCreate model);
        public IEnumerable<MySceneListItem> GetMyScenes();
        public MySceneDetail GetMySceneById(Guid userId);
    }
}
