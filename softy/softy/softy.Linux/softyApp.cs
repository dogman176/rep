using SiliconStudio.Xenko.Engine;

namespace softy
{
    class softyApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
