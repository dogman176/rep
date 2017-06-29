using System;
using System.Threading.Tasks;
using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Xenko.Engine;
using SiliconStudio.Xenko.Rendering.Sprites;

namespace softy
{
    

    public class SpriteTest : SyncScript
    {
        // Declared public member fields and properties are displayed in Game Studio.
        private SpriteFromSheet sprite;
        private DateTime lastFrame;

        public override void Start()
        {
            // Initialize the script.
            sprite = Entity.Get<SpriteComponent>().SpriteProvider as SpriteFromSheet;
            lastFrame = DateTime.Now;
        }

        public override void Update()
        {
            // Do something every new frame.
            if ((DateTime.Now - lastFrame) > new TimeSpan(0, 0, 0))
            {
                sprite.CurrentFrame += 1;
                lastFrame = DateTime.Now;
            }
        }
    }
}
