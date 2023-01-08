using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core.Interfaces;
using My2DGame.Displayers;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace My2DGame.Managers
{
    internal class DisplayManager : IGameObject
    {
        public CoinDisplayer CoinDisplayer { get; private set; }
        public HealthDisplayer HealthDisplayer { get; private set; }
        public DisplayManager(ContentManager content)
        {
            CoinDisplayer = new CoinDisplayer(content);
            HealthDisplayer = null;
        }

        public DisplayManager(ContentManager content, int lives)
        {
            CoinDisplayer = new CoinDisplayer(content);
            HealthDisplayer = new HealthDisplayer(content, lives);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            CoinDisplayer.Draw(spriteBatch);
            HealthDisplayer.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            CoinDisplayer.Update(gameTime);
            HealthDisplayer.Update(gameTime);
        }
    }
}
