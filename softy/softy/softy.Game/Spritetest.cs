using System;
using System.Threading.Tasks;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Xenko.Input;
using SiliconStudio.Xenko.Physics;
using SiliconStudio.Xenko.Engine;
using SiliconStudio.Xenko.Rendering.Sprites;

//I was going to write documentation for this
// Until i realized it is pointles since this script is going to be changing so quickly 
// that is might as well not exsist

namespace softy
{
    public class SpriteTest : AsyncScript
    {
        private SpriteFromSheet sprite;
        private CharacterComponent CharPlayer;
        private int x=0;

        public override async Task Execute()
        {
            sprite = Entity.Get<SpriteComponent>().SpriteProvider as SpriteFromSheet;
            CharPlayer = Entity.Get<CharacterComponent>() as CharacterComponent;
            while (Game.IsRunning)
            {
                await Script.NextFrame();
                if (Input.KeyDown.Count < 1 && sprite.CurrentFrame != 1)
                {
                    sprite.CurrentFrame = 1;
                }else
                    if(Input.IsKeyDown(Keys.A))
                {
                    //ToDo- Find a way to read Velocity!
                    Entity.Transform.Scale.X = -1;
                    float Increment = -0.01f;
                    while (Input.IsKeyDown(Keys.A))
                    {
                        Walk();
                        await Script.NextFrame();
                        if (Increment > -1.9f)
                        {
                            CharPlayer.SetVelocity(new Vector3(Increment, 0, 0));
                            if (Increment > -0.9f) { Increment -= 0.005f; await Script.NextFrame(); }
                            await Script.NextFrame();
                            Increment -= 0.015f;
                        }
                        if (Increment > -2.3f) Increment -= 0.1f;
                    }
                    CharPlayer.SetVelocity(new Vector3(0, 0, 0));
                }else
                    if (Input.IsKeyDown(Keys.D))
                {
                    Entity.Transform.Scale.X = 1;
                    float Inc = 0.01f;
                    while (Input.IsKeyDown(Keys.D))
                    {
                        Walk();
                        await Script.NextFrame();
                        if (Inc < 1.9f)
                        {
                            CharPlayer.SetVelocity(new Vector3(Inc, 0, 0));
                            if (Inc < 0.9f) { Inc += 0.005f; await Script.NextFrame(); }
                            await Script.NextFrame();
                            Inc += 0.015f;
                        }
                        if (Inc < 2.3f) Inc += 0.1f;
                    }
                    CharPlayer.SetVelocity(new Vector3(0, 0, 0));
                }
            }
        }

        private void Walk()
        {
            if (x > 5)
            {
                sprite.CurrentFrame += 1;
                x = 0;
            }
            x++;
        }
    }
}
