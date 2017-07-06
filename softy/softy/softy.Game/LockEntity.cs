using System.Linq;
using System.Threading.Tasks;
using SiliconStudio.Xenko.Engine;

//This script will lock the possition of any entity with to the entity this is attached to.

namespace softy
{
    public class LockEntityX : AsyncScript
    {
        //Name of entity
        public string EntityToAttach = "Camera";
        public bool PositionX = false;
        public float OffsetX = 0;
        public bool PositionY = false;
        public float OffsetY = 0;
        public bool PositionZ = false;
        public float OffsetZ = 0;

        public override async Task Execute()
        {
            var EntityToLock = (from All_Entities in this.SceneSystem.SceneInstance
                              where All_Entities.Name == EntityToAttach
                              select All_Entities).FirstOrDefault();
            if (EntityToLock == null) return;

            while (Game.IsRunning)
            {
                await Script.NextFrame();
                if (PositionX)
                {
                    if (EntityToLock.Transform.Position.X != Entity.Transform.Position.X+OffsetX)
                        EntityToLock.Transform.Position.X = Entity.Transform.Position.X+OffsetX;
                }
                if (PositionY)
                {
                    if (EntityToLock.Transform.Position.Y != Entity.Transform.Position.Y + OffsetY)
                        EntityToLock.Transform.Position.Y = Entity.Transform.Position.Y + OffsetY;
                }
                if (PositionZ)
                {
                    if (EntityToLock.Transform.Position.Z != Entity.Transform.Position.Z + OffsetZ)
                        EntityToLock.Transform.Position.Z = Entity.Transform.Position.Z + OffsetZ;
                }
            }
        }
    }
}
