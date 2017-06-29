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
            while (Game.IsRunning)
            {
                await Script.NextFrame();
                if (Input.IsKeyDown(Keys.Y))
                {
                    if (Entity.Transform.Position.Y < 4)
                    {
                        Entity.Transform.Position.Y += 0.1f;
                    }
                    else
                        while (Entity.Transform.Position.Y > 0)
                        {
                            await Script.NextFrame();
                        }
                }

            }
        }
    }
}
