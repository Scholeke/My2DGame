using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Animations;
using My2DGame.Core;
using My2DGame.Core.Interfaces;
using My2DGame.Levels;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace My2DGame.Enemies
{
    internal class EvilDino : Enemy
    {

        public EvilDino(ContentManager content, Vector2 startPosition,int velocity,  int range) : base(startPosition,velocity, range)
        {
            Texture = content.Load<Texture2D>("evildinospritesheet");
            //Animations
            MovingRight = new Animation();
            MovingRight.GetFramesFromTextureProperties(168, 24, 7, 1, 96);
            MovingLeft = new Animation();
            MovingLeft.GetFramesFromTexturePropertiesToLeft(168, 24, 7, 1, 480);
            Animation = MovingRight;
        }

        public override void Collide(Hero hero, Level level)
        {
            if (hero.Rectangle.TouchTopOf(Rectangle))
            {
                hero.SetYVelocity(-3f);
                level.RemovedObjects.Add(this);
            }
            if (hero.Rectangle.TouchLeftOf(Rectangle))
            {
                hero.SetXPosition(Rectangle.X - hero.Rectangle.Width - 4);
                hero.DisplayManager.HealthDisplayer.TakeLife();
            }
            if (hero.Rectangle.TouchRightOf(Rectangle))
            {
                hero.SetXPosition(Rectangle.X + hero.Rectangle.Width + 4);
                hero.DisplayManager.HealthDisplayer.TakeLife();
            }
            if (hero.Rectangle.TouchBottomOf(Rectangle))
            {
                hero.DisplayManager.HealthDisplayer.TakeLife();
            }
        }

    }
}
