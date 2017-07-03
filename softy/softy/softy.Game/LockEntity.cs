using System.Linq;
using System.Threading.Tasks;
using SiliconStudio.Xenko.Engine;

namespace softy
{
    public class LockEntityX : AsyncScript
    {
        public string EntityToAttach = "Camera";
        public bool PositionX = false;
        public float OffsetX = 0;
        public bool PositionY = false;
        public float OffsetY = 0;
        public bool PositionZ = false;
        public float OffsetZ = 0;

        public override async Task Execute()
        {
            var LockedEntity = (from All_Entities in this.SceneSystem.SceneInstance
                              where All_Entities.Name == EntityToAttach
                              select All_Entities).FirstOrDefault();
            if (LockedEntity == null) return;

            while (Game.IsRunning)
            {
                await Script.NextFrame();
                if (PositionX)
                {
                    if (LockedEntity.Transform.Position.X != Entity.Transform.Position.X+OffsetX)
                        LockedEntity.Transform.Position.X = Entity.Transform.Position.X+OffsetX;
                }
                if (PositionY)
                {
                    if (LockedEntity.Transform.Position.Y != Entity.Transform.Position.Y + OffsetY)
                        LockedEntity.Transform.Position.Y = Entity.Transform.Position.Y + OffsetY;
                }
                if (PositionZ)
                {
                    if (LockedEntity.Transform.Position.Z != Entity.Transform.Position.Z + OffsetZ)
                        LockedEntity.Transform.Position.Z = Entity.Transform.Position.Z + OffsetZ;
                }
            }
        }
    }
}
