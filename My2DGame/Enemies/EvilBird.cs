using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Animations;
using My2DGame.Core;
using My2DGame.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Enemies
{
    internal class EvilBird : Enemy
    {
        public EvilBird(ContentManager content, Vector2 startPosition, int velocity, int range) : base(startPosition, velocity, range)
        {
            Texture = content.Load<Texture2D>("BirdSprite");
            MovingRight = new Animation();
            MovingRight.GetFramesFromTextureProperties(128, 16, 8, 1, 0);
            MovingLeft = new Animation();
            MovingLeft.GetFramesFromTexturePropertiesToLeft(128, 16, 8, 1, 112);
            Animation = MovingRight;
        }

        public override void Collide(Hero hero)
        {
            if (hero.Rectangle.Intersects(Rectangle))
            {
                hero.DisplayManager.HealthDisplayer.TakeLife();
            }
        }
    }
}
