using System;
using System.Threading.Tasks;
using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Xenko.Engine;
using SiliconStudio.Xenko.Input;

//This a test script used to move the ball attached to the player

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
                    if (Entity.Transform.Position.Y < 1.7)
                    {
                        Entity.Transform.Position.Y += 0.1f;
                    }
                    else
                        while (Entity.Transform.Position.Y > -1)
                        {
                            await Script.NextFrame();
                            Entity.Transform.Position.Y -= 0.1f;
                        }
                }

            }
        }
    }
}
