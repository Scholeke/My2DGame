using Microsoft.Xna.Framework;
using My2DGame.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Core.Interfaces
{
    internal interface ICollidable
    {
        public Rectangle Rectangle { get; set; }
        public void Collide(Hero hero, Level level);
    }
}
