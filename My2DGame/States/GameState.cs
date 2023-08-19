using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My2DGame.Core.Interfaces;
using System.Windows.Forms;
using SharpDX.MediaFoundation;
using My2DGame.Core;
using My2DGame.Managers;
using My2DGame.Levels;
using My2DGame.Blocks;
using My2DGame.Enemies;
using System.Reflection.Metadata;
using IDrawable = My2DGame.Core.Interfaces.IDrawable;

namespace My2DGame.Scenes
{
    internal class GameState : State
    {
        public LevelManager Level { get; set; }
        public override void LoadContent(ContentManager content)
        {
            Level = LevelManager.Instance;
            Level.Initialize();

        }

        public override void Update(GameTime gameTime)
        {
            Level.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Level.Draw(spriteBatch);

        }


    }
}

