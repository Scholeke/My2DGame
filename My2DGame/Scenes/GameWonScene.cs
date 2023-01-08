using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using My2DGame.Core;
using My2DGame.Levels;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Scenes
{
    internal class GameWonScene : MenuScene
    {
        public bool NextLevel { get; set; } = false;
        public GameWonScene()
        {
            MAX_BTNS = 3;
            Buttons = new Button[MAX_BTNS];
        }
        public override void Update(GameTime gameTime)
        {
            MS = Mouse.GetState();
            base.Update(gameTime);
            if (MS.LeftButton == ButtonState.Pressed && MouseRectangle.Intersects(Buttons[2].Rectangle))
            {
                NextLevel = true;
                Data.CurrentState = Data.Scenes.Game;
            }
        }
        public GameScene NewLevel(ContentManager content, Level level)
        {
            GameScene newGame = new GameScene(level);
            newGame.LoadContent(content);
            return newGame;
        }

    }
}
