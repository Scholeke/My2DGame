using My2DGame.Blocks;
using My2DGame.Buffs;
using My2DGame.Core;
using My2DGame.Core.Interfaces;
using My2DGame.Enemies;
using My2DGame.Levels;
using My2DGame.PickupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Managers
{
    internal class CollisionManager
    {
        public List<ICollidable> Removables { get; set; }

        public CollisionManager()
        {
            Removables = new List<ICollidable>();
        }
        public void CheckCollisions(Hero hero, ICollidable b)
        {
            if(b is EvilDino)
            {
                if (hero.Rectangle.TouchTopOf(b.Rectangle))
                {
                    hero.SetYVelocity(-3f);
                    Removables.Add(b);
                }
                else
                    b.Collide(hero);
            }
            if(b is PickupItem)
            {
                if (hero.Rectangle.Intersects(b.Rectangle))
                {
                    b.Collide(hero);
                    Removables.Add(b);
                }
            }
            else
            {
                b.Collide(hero);
            }
        }
    }
}
