using System;

namespace DungeonCrawlerGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new DcGame())
                game.Run();
        }
    }
}
