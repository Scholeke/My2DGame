using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace My2DGame.Core.Interfaces
{
    internal interface IComponent : IGameObject
    {
        void LoadContent(ContentManager content);
    }
}
