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
            int lenght=0;
            while(Game.IsRunning)
            {
                await Script.NextFrame();
                if (lenght<50)
                {
                    lenght += 1;
                    Entity.Transform.Position.X -= 0.1f;
                }else
                    while (lenght>-40)
                    {
                        await Script.NextFrame();
                        lenght -= 1;
                        Entity.Transform.Position.X += 0.1f;
                    }
            }


        }
    }
}
