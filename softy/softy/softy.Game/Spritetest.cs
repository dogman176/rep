using System;
using System.Threading.Tasks;
using SiliconStudio.Xenko.Input;
using SiliconStudio.Core.Native;
using SiliconStudio.Xenko.Engine;
using SiliconStudio.Xenko.Rendering.Sprites;

namespace softy
{


    public class SpriteTest : AsyncScript
    {
        private SpriteFromSheet sprite;
        private int x=0;

        public override async Task Execute()
        {
            sprite = Entity.Get<SpriteComponent>().SpriteProvider as SpriteFromSheet;

            while (Game.IsRunning)
            {
                await Script.NextFrame();
                if (Input.KeyDown.Count < 1 && sprite.CurrentFrame != 1)
                {
                    sprite.CurrentFrame = 1;
                }else
                    if(Input.IsKeyDown(Keys.A))
                {
                    Walk(Keys.A);
                }else
                    if (Input.IsKeyDown(Keys.D))
                {
                    Walk(Keys.D);
                }else
                    if(Input.IsKeyDown(Keys.W))
                {
                    //Jump();
                }
            }
        }

        private void Walk(Keys PKey)
        {
            if (PKey == Keys.A)
            {
                Entity.Transform.Scale.X = -1;
                Entity.Transform.Position.X -= 0.1f;
            }
            else
            if (PKey == Keys.D)
            {
                Entity.Transform.Scale.X = 1;
                Entity.Transform.Position.X += 0.1f;
            }
            if (x > 5)
            {
                sprite.CurrentFrame += 1;
                x = 0;
            }
            x++; 
        }

       /* private void Jump()
        {
            for (int x = 0; x < 5; x++)
            {
                Entity.Transform.Position.Y += 0.2f;               
            }
            while (Entity.Transform.Position.Y == 0)
            {
                Entity.Transform.Position.Y -= 0.1f;
            }
        }*/
    }
}
