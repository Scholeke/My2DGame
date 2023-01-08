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
    internal class GameScene : Scene
    {
        private Hero _hero;
        public Level CurrentLevel { get; set; }
        public GameScene(Level level)
        {
            CurrentLevel = level;
        }
        public override void LoadContent(ContentManager content)
        {
            _hero = new Hero(content);
            CurrentLevel.Initialize();

        }

        public override void Update(GameTime gameTime)
        {
            Collide();
            _hero.Update(gameTime);

            CurrentLevel.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            CurrentLevel.Draw(spriteBatch);
            _hero.Draw(spriteBatch);

        }

        private void Collide()
        {
            foreach (IDrawable obj in CurrentLevel.Drawables)
            {
                if (obj is ICollidable)
                {
                    ICollidable c = (ICollidable)obj;
                    c.Collide(_hero, CurrentLevel);
                }
            }
        }

    }
}

