using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using My2DGame.Enemies;

namespace My2DGame.Input
{
    internal interface IInputReader
    {
        Vector2 ReadInput();
    }
}
