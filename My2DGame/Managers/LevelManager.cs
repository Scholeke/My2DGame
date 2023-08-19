using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core;
using My2DGame.Core.Interfaces;
using My2DGame.Levels;

namespace My2DGame.Managers
{
    internal class LevelManager : IGameObject
    {
        public Hero Hero { get; set; }
        public Level CurrentLevel { get; set; }
        public static LevelManager Instance { 
            get
            {
                if (_instance == null)
                    _instance = new LevelManager();
                return _instance;
            } 
        }
        private Level1 level1;
        private Level2 level2;
        private ContentManager _content;
        private static LevelManager _instance;
        public CollisionManager CollisionManager { get; set; }

        private LevelManager()
        {
            CollisionManager = new CollisionManager();
            _content = Game1.Instance.Content;
            Hero = new Hero(_content);
            level1 = new Level1(_content);
            level2 = new Level2(_content);
            CurrentLevel = level1;
        }

        public void Initialize()
        {
            CurrentLevel.Initialize();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentLevel.Draw(spriteBatch);
            Hero.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            Collide();
            Hero.Update(gameTime);
            CurrentLevel.Update(gameTime);
        }

        public void Restart()
        {
            Hero = new Hero(_content);
            level1 = new Level1(_content);
            level2 = new Level2(_content);
            CurrentLevel = level1;
            CurrentLevel.Initialize();

        }

        public void StartTwo()
        {
            Hero = new Hero(_content);
            CurrentLevel = level2;
            CurrentLevel.Initialize();
        }

        private void Collide()
        {
            foreach (ICollidable c in CurrentLevel.Collidables)
            {
                CollisionManager.CheckCollisions(Hero, c);
                CurrentLevel.RemovedObjects = CollisionManager.Removables;
            }
        }
    }
}
