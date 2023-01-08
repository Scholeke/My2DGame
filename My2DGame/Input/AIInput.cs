using Microsoft.Xna.Framework;
using My2DGame.Animations;
using My2DGame.Core;
using My2DGame.Enemies;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Input
{
    internal class AIInput// : IInputReader
    {
        public Vector2 ReadInput(Enemy enemy)
        {
            Vector2 direction = Vector2.Zero;
            if (enemy.Position.X >= enemy.StartPosition.X + enemy.Range)
            {
                direction.X = -1;
            }
            if (enemy.Position.X <= enemy.StartPosition.X - 1)
            {
                direction.X = 1;
            }
            return direction;
        }
    }
}
