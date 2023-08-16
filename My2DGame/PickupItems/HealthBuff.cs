using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core;
using My2DGame.Levels;
using My2DGame.PickupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Buffs
{
    internal class HealthBuff : PickupItem
    {
        public HealthBuff(ContentManager content, Vector2 position) : base(position, 20)
        {
            Texture = content.Load<Texture2D>("Heart");
        }
        public override void Collide(Hero hero)
        {
                hero.DisplayManager.HealthDisplayer.AddLife();
        }

    }
}
