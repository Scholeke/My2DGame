using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Blocks
{
    internal class GroundBlock : CollisionBlock
    {
        public GroundBlock(Rectangle rectangle, Color color, Texture2D texture, Rectangle tile) : base(rectangle, color, texture)
        {
            Tile = tile;
        }
    }
}
