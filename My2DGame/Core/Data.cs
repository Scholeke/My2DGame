using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Core
{
    internal static class Data
    {
        public static int ScreenWidth { get; set; } = 1600;
        public static int ScreenHeight { get; set; } = 900;
        public static bool Exit { get; set; } = false;

        public static Scenes CurrentState { get; set; } = Scenes.Menu;
        public enum Scenes
        {
            Menu, Game, GameOver, GameWon, End
        }
    }
}
