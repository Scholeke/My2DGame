using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Animations;
using My2DGame.Core;
using My2DGame.Core.Interfaces;
using My2DGame.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Enemies
{
    internal abstract class Enemy : AnimatedSprite, ICollidable, IGameObject
    {
        public int Range { get; set; }

        public float Timer { get; set; }

        public Enemy(Vector2 startPosition, int velocity, int range)
        {
            StartPosition = startPosition;
            Range = range;
            Position = startPosition;
            Velocity = new Vector2(velocity, 0);
            Rectangle = new Rectangle((int)StartPosition.X, (int)StartPosition.Y, 64, 64);
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Animation.Update(gameTime);

        }

        private void Move()
        {
            if (position.X >= StartPosition.X + Range)
            {
                velocity.X *= -1;
                Animation = MovingLeft;
            }
            if (position.X <= StartPosition.X - 1)
            {
                velocity.X *= -1;
                Animation = MovingRight;
            }
            position.X += velocity.X;
            Rectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);

        }

        public abstract void Collide(Hero hero, Level level);

    }
}
