using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using My2DGame.Core;
using My2DGame.Levels;
using My2DGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Scenes
{
    internal class GameOverState : MenuState
    {
        public bool NextGame { get; set; } = false;
        private Texture2D mainText;

        private Texture2D[] btns; 
        private Rectangle[] btnRectangles;

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, new Rectangle(0, 0, Data.ScreenWidth, Data.ScreenHeight), Color.White);
            spriteBatch.Draw(mainText, new Rectangle(500, 400, 600, 200), Color.Red);
            for (int i = 0; i < btns.Length; i++)
            {
                spriteBatch.Draw(btns[i], btnRectangles[i], Color.White);
                if (MouseRectangle.Intersects(btnRectangles[i]))
                {
                    spriteBatch.Draw(btns[i], btnRectangles[i], Color.Green);
                }
            }
        }

        public override void LoadContent(ContentManager content)
        {
            btns = new Texture2D[MAX_BTNS];
            btnRectangles = new Rectangle[MAX_BTNS];
            const int INCREMENT_VALUE = 175;
            Background = content.Load<Texture2D>("forest2");
            mainText = content.Load<Texture2D>("GameOver");
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = content.Load<Texture2D>($"Btn{i}");
                btnRectangles[i] = new Rectangle(550 + (INCREMENT_VALUE * i), 600, btns[i].Width / 2, btns[i].Height / 2);
            }
        }

        public override void Update(GameTime gameTime)
        {
            MS = Mouse.GetState();
            MouseRectangle = new Rectangle(MS.X, MS.Y, 1, 1);

            if (MS.LeftButton == ButtonState.Pressed && MouseRectangle.Intersects(btnRectangles[0]))
            {
                LevelManager.GetInstance().Restart();
                Data.CurrentState = Data.States.Game;
            }
            else if (MS.LeftButton == ButtonState.Pressed && MouseRectangle.Intersects(btnRectangles[1]))
                Game1.Instance.Exit();
        }
    }
    
}
