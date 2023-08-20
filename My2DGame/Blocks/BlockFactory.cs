using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Blocks
{
    internal class BlockFactory
    {
        public Block Create(string type, Rectangle rectangle, Color color, Texture2D texture)
        {
            try
            {
                Block b = (Block)Activator.CreateInstance(Type.GetType($"My2DGame.Blocks.{type}"), new Object[] { rectangle, color, texture });
                return b;
            }
            catch
            {
                return null;
            }
        }
    }
}
