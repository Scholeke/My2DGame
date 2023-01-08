using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Animations;
using My2DGame.Core.Interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Core
{
    internal abstract class AnimatedSprite : IGameObject
    {
        protected Rectangle rectangle;
        protected Vector2 velocity;
        protected Vector2 position;
        private Animation movingRight;
        private Animation movingLeft;

        private Vector2 startPosition;

        public Rectangle Rectangle { get => rectangle; set => rectangle = value; }

        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public Vector2 Position { get => position; set => position = value; }
        private Animation animation;

        public Texture2D Texture { get; set; }
        public Animation MovingRight { get => movingRight; set => movingRight = value; }
        public Animation MovingLeft { get => movingLeft; set => movingLeft = value; }


        public Animation Animation { get => animation; set => animation = value; }
        public Vector2 StartPosition { get => startPosition; set => startPosition = value; }

        public AnimatedSprite()
        {

        }
        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
