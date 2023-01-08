using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Animations;
using My2DGame.Core;
using My2DGame.Levels;
using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

namespace My2DGame.Blocks
{
    internal class MovingBlock : GroundBlock
    {
        public Vector2 StartPosition { get => startPosition; set => startPosition = value; }
        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public int Range { get; private set; }
        private Vector2 velocity;
        private Vector2 position;
        private Vector2 startPosition;

        public MovingBlock(Rectangle rectangle, Color color, Texture2D texture, Rectangle tile) : base(rectangle, color, texture, tile)
        {
            startPosition.X = rectangle.X;
            startPosition.Y = rectangle.Y;
            Range = 300;
            position.X = rectangle.X;
            position.Y = rectangle.Y;
            Tile = tile;
            velocity = new Vector2(4, 0);
        }

        public void Move()
        {
            if (position.X >= StartPosition.X + Range)
            {
                velocity.X *= -1;
            }
            if (position.X <= StartPosition.X - 1)
            {
                velocity.X *= -1;
            }
            position.X += velocity.X;
            Rectangle = new Rectangle((int)position.X, (int)position.Y, 45, 45);
        }

        public void Update(GameTime time)
        {
            Move();
        }
        new public void Collide(Hero hero, Level level)
        {
            if (hero.Rectangle.TouchTopOf(Rectangle))
            {
                hero.SetYPosition(Rectangle.Y - hero.Rectangle.Height + 4);
                hero.SetXPosition(Rectangle.X + Rectangle.Width / 2);
                hero.SetYVelocity(0f);
                hero.HasJumped = false;
            }
        }
    }
}
