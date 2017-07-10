using System.Threading.Tasks;
using SiliconStudio.Xenko.Input;
using SiliconStudio.Xenko.Physics;
using SiliconStudio.Xenko.Engine;

//Used to make the character jump

namespace softy
{
    public class _Character_Jump : AsyncScript
    {
        private CharacterComponent CharPlayer;
        public override async Task Execute()
        {
            CharPlayer= Entity.Get<CharacterComponent>() as CharacterComponent;
            while (Game.IsRunning)
            {
                await Script.NextFrame();
                if (Input.IsKeyDown(Keys.W) || Input.IsKeyDown(Keys.Space))
                {
                    if(CharPlayer.IsGrounded)
                    CharPlayer.Jump();
                }
            }
        }
    }
}