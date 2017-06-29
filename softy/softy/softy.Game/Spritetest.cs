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
        private int Stuff=0;

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
                    Anim(Keys.A);
                }else
                    if (Input.IsKeyDown(Keys.D))
                {
                    Anim(Keys.D);
                }
            }
        }
        private void Anim(Keys PKey)
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
            if (Stuff > 5)
            {
                sprite.CurrentFrame += 1;
                Stuff = 0;
            }
            Stuff++; 
        }
    }
}
