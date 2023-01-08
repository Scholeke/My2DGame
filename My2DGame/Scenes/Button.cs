using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDrawable = My2DGame.Core.Interfaces.IDrawable;

namespace My2DGame.Scenes
{
    internal class Button : IDrawable
    {
        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }

        public Button(Texture2D texture, Rectangle btnRectangle)
        {
            Texture = texture;
            Rectangle = btnRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }

    }
}
