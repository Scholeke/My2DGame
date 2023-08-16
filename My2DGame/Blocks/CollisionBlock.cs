using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core;
using My2DGame.Core.Interfaces;
using My2DGame.Enemies;
using My2DGame.Levels;
using My2DGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Blocks
{
    internal abstract class CollisionBlock : Block, ICollidable
    {
        public CollisionBlock(Rectangle rectangle, Color color, Texture2D texture) : base(rectangle, color, texture)
        {
        }

        public void Collide(Hero hero)
        {
            if (hero.Rectangle.TouchTopOf(Rectangle))
            {
                hero.SetYPosition(Rectangle.Y - hero.Rectangle.Height + 6);
                hero.SetYVelocity(0f);
                hero.HasJumped = false;
            }
            if (hero.Rectangle.TouchLeftOf(Rectangle))
            {
                hero.SetXPosition(Rectangle.X - hero.Rectangle.Width - 4);
            }
            if (hero.Rectangle.TouchRightOf(Rectangle))
            {
                hero.SetXPosition(Rectangle.X + Rectangle.Width);
            }
            if (hero.Rectangle.TouchBottomOf(Rectangle))
            {
                hero.SetYVelocity(1f);
            }
        }
    }
}
