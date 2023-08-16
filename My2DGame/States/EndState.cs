using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using My2DGame.Core;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Scenes
{
    internal class EndState : State
    {
        private Texture2D mainText;
        private Button exitButton;
        public MouseState MS { get; set; }
        public Rectangle MouseRectangle { get; set; }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, new Rectangle(0, 0, Data.ScreenWidth, Data.ScreenHeight), Color.White);
            spriteBatch.Draw(mainText, new Rectangle(500, 270, 600, 200), Color.Red);
            spriteBatch.Draw(exitButton.Texture, exitButton.Rectangle, Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            Background = content.Load<Texture2D>("forest2");
            mainText = content.Load<Texture2D>("TheEnd");
            exitButton = new Button(content.Load<Texture2D>("btn1"), new Rectangle(750, 500, 100 , 50));

        }

        public override void Update(GameTime gameTime)
        {
            MS = Mouse.GetState();
            MouseRectangle = new Rectangle(MS.X, MS.Y, 1, 1);
            if (MS.LeftButton == ButtonState.Pressed && MouseRectangle.Intersects(exitButton.Rectangle))
                Game1.Instance.Exit();
        }
    }
}
