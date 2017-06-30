using System;
using System.Linq;
using System.Threading.Tasks;
using SiliconStudio.Xenko.Input;
using SiliconStudio.Core.Native;
using SiliconStudio.Xenko.Engine;

namespace softy
{
    public class LockEntityX : AsyncScript
    {
        public string EntityToAttach = "Camera";
        public override async Task Execute()
        {
            await Script.NextFrame();
            var GameCamera = (from All_Entities in this.SceneSystem.SceneInstance
                              where All_Entities.Name == EntityToAttach
                              select All_Entities).FirstOrDefault();
            if (GameCamera == null) return;

            while (Game.IsRunning)
            {
                await Script.NextFrame();
                if (GameCamera.Transform.Position.X != Entity.Transform.Position.X)
                    GameCamera.Transform.Position.X = Entity.Transform.Position.X;
            }
        }
    }
}
