using System.Threading.Tasks;
using SiliconStudio.Xenko.Engine;
using SiliconStudio.Xenko.UI;
using SiliconStudio.Xenko.UI.Controls;

namespace softy
{
    class _UIAtempt : AsyncScript
    {
        public override async Task Execute()
        {
            await Script.NextFrame();
            UIComponent Dingus = Entity.Get<UIComponent>();

            Dingus.Page.RootElement.FindVisualChildOfType<Button>("2Dbutt").Click += delegate
            {
                var myScene = Content.Load<Scene>("Scene2D");
                SceneSystem.SceneInstance.RootScene = myScene;
            };
            Dingus.Page.RootElement.FindVisualChildOfType<Button>("3Dbutt").Click += delegate
            {
                var myScene = Content.Load<Scene>("Scene3D");
                SceneSystem.SceneInstance.RootScene = myScene;
            };
        }
    }
}
