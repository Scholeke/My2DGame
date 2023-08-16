using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core;
using My2DGame.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.PickupItems
{
    internal class Coin : PickupItem
    {
        public Coin(ContentManager content, Vector2 position) : base(position, 40)
        {
            Texture = content.Load<Texture2D>("coin");
        }
        public override void Collide(Hero hero)
        {
                hero.DisplayManager.CoinDisplayer.AddCoin();
        }
    }
}
