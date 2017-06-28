using System;
using System.Threading.Tasks;
using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Xenko.Engine;
using SiliconStudio.Xenko.Input;

namespace softy
{
  public class hard : AsyncScript
    {
        public override async Task Execute()
        {
            while(Game.IsRunning)
            {
                await Script.NextFrame();
                Entity.Transform.Position.X += 0.01f;
            }


        }
    }
}
