using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Input
{
    internal class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            KeyboardState keyboard = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (keyboard.IsKeyDown(Keys.A))
            {
                direction.X -= 1;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                direction.X += 1;
            }
            if(keyboard.IsKeyDown(Keys.Space))
            {
                direction.Y -= 1;
            }
            return direction;
        }
    }
}
