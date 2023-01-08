using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Animations;
using My2DGame.Input;
using My2DGame.Managers;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Core
{
    internal class Hero : AnimatedSprite
    {
        private MovementManager _movement;
        private IInputReader _input;
        public DisplayManager DisplayManager { get; set; }
        public bool HasJumped { get; set; }
        private Animation idleLeft;
        private Animation idleRight;
        public Animation IdleLeft { get => idleLeft; set => idleLeft = value; }
        public Animation IdleRight { get => idleRight; set => idleRight = value; }
        public Hero(ContentManager content)
        {
            DisplayManager = new DisplayManager(content, 3);
            Texture = content.Load<Texture2D>("dinospritesheet");
            position = new Vector2(200, 400);
            Rectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
            velocity = new Vector2(3, 7);
            _input = new KeyboardReader();
            HasJumped = false;

            //Animation
            IdleRight = new Animation();
            IdleRight.GetFramesFromTextureProperties(96, 24, 4, 1, 0);
            Animation = IdleRight;

            MovingRight = new Animation();
            MovingRight.GetFramesFromTextureProperties(168, 24, 7, 1, 96);
            MovingLeft = new Animation();
            MovingLeft.GetFramesFromTexturePropertiesToLeft(168, 24, 7, 1, 480);
            IdleLeft = new Animation();
            IdleLeft.GetFramesFromTexturePropertiesToLeft(96, 24, 4, 1, 552);

            _movement = new MovementManager(_input);
        }

        public override void Update(GameTime gameTime)
        {
            DisplayManager.Update(gameTime);
            _movement.Move(this);
            Animation.Update(gameTime);
            BorderCollision();
            Gravity();
        }
        public Vector2 CheckJump(Vector2 direction)
        {
            if (direction.Y <= -1 && !HasJumped)
            {
                position.Y -= 2;
                velocity.Y = -5;
                HasJumped = true;
            }
            if (HasJumped)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
                direction.Y = 1;
            }
            return direction;
        }
        new public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            DisplayManager.Draw(spriteBatch);
        }

        public void BorderCollision()
        {
            if (position.X < 0) position.X = 0;
            if (position.X > Data.ScreenWidth - Rectangle.Width) position.X = Data.ScreenWidth - Rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > Data.ScreenHeight - Rectangle.Height)
            {
                Data.CurrentState = Data.Scenes.GameOver;
            }
        }

        public void Gravity()
        {
            if (!HasJumped)
                velocity.Y = 7;
            //Gravity
            position.Y += velocity.Y;
        }

        public void SetYPosition(float y)
        {
            position.Y = y;
        }
        public void SetYVelocity(float y)
        {
            velocity.Y = y;
        }
        public void SetXPosition(float x)
        {
            position.X = x;
        }
    }
}
