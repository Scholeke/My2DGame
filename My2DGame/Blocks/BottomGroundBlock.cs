﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Blocks
{
    internal class BottomGroundBlock : CollisionBlock
    {
        public BottomGroundBlock(Rectangle rectangle, Color color, Texture2D texture) : base(rectangle, color, texture, new Rectangle(16, 32, 16, 16))
        {

        }
    }
}
