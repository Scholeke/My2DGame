using Microsoft.Xna.Framework;
using My2DGame.Core.Interfaces;
using My2DGame.Core;
using My2DGame.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = My2DGame.Core.Interfaces.IDrawable;

namespace My2DGame.PickupItems
{
    internal abstract class PickupItem : IDrawable, ICollidable
    {
        private Vector2 position;

        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }

        public Vector2 Position { get => position; set => position = value; }

        public PickupItem(Vector2 position, int size, Texture2D texture)
        {
            Position = position;
            Rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, size, size);
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }

        public abstract void Collide(Hero hero);

    }
}
