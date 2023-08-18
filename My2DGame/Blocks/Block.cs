using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDrawable = My2DGame.Core.Interfaces.IDrawable;

namespace My2DGame.Blocks
{
    internal abstract class Block : IDrawable
    {
        public Rectangle Rectangle { get; set; }
        private Color _color;
        private Texture2D _texture;
        private Rectangle _tile { get; set; }
        public Block(Rectangle rectangle, Color color, Texture2D texture, Rectangle tile)
        {
            Rectangle = rectangle;
            _color = color;
            _texture = texture;
            _tile = tile;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rectangle, _tile, _color);
        }
    }
}
