using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using My2DGame.Managers;

namespace My2DGame.Scenes
{
    internal class MenuState : State
    {
        protected int MAX_BTNS = 2;
        public Button[] Buttons { get; set; }
        public MenuState()
        {
            Buttons = new Button[MAX_BTNS];
        }

        public MouseState MS { get; set; }
        public Rectangle MouseRectangle { get; set; }

        #region Methods
        public override void LoadContent(ContentManager content)
        {
            Background = content.Load<Texture2D>("forest2");
            const int INCREMENT_VALUE = 175;
            for (int i = 0; i < Buttons.Length; i++)
            {
                Texture2D texture = content.Load<Texture2D>($"Btn{i}");
                Buttons[i] = new Button(texture,
                    new Rectangle(550 + (INCREMENT_VALUE * i), 450, texture.Width / 2, texture.Height / 2));
            }
        }

        public override void Update(GameTime gameTime)
        {
            MS = Mouse.GetState();
            MouseRectangle = new Rectangle(MS.X, MS.Y, 1, 1);

            if (MS.LeftButton == ButtonState.Pressed && MouseRectangle.Intersects(Buttons[0].Rectangle))
            {
                LevelManager.GetInstance().Restart();
                Data.CurrentState = Data.States.Game;
            }
            else if(MS.LeftButton == ButtonState.Pressed && MouseRectangle.Intersects(Buttons[1].Rectangle))
                Game1.Instance.Exit();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, new Rectangle(0,0, Data.ScreenWidth, Data.ScreenHeight), Color.White);
            foreach (Button b in Buttons)
            {
                spriteBatch.Draw(b.Texture, b.Rectangle, Color.White);
                if (MouseRectangle.Intersects(b.Rectangle))
                    spriteBatch.Draw(b.Texture, b.Rectangle, Color.Transparent);
            }
        }
        #endregion

    }
}
