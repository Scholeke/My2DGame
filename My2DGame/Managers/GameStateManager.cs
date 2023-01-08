using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core;
using My2DGame.Scenes;
using My2DGame.Core.Interfaces;
using My2DGame.Levels;

namespace My2DGame.Managers
{
    internal class GameStateManager : IComponent
    {
        private List<Level> levels = new List<Level>();
        private MenuScene _ms = new MenuScene();
        private GameScene _gs;
        private GameOverScene _gOs = new GameOverScene();
        private GameWonScene _gws = new GameWonScene();
        private EndScene _es = new EndScene();
        private ContentManager _content;
        private int currentLevel;
        public void LoadContent(ContentManager content)
        {
            levels.Add(new Level1(content));
            levels.Add(new Level2(content));
            _content = content;
            _gs = new GameScene(levels[currentLevel]);
            _ms.LoadContent(content);
            _gs.LoadContent(content);
            _gOs.LoadContent(content);
            _gws.LoadContent(content);
            _es.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            switch(Data.CurrentState)
            {
                case Data.Scenes.Menu:
                    _ms.Update(gameTime);
                    break;
                case Data.Scenes.Game:
                    _gs.Update(gameTime);
                    break;
                case Data.Scenes.GameOver:
                    _gOs.Update(gameTime);
                    if (_gOs.NextGame)
                        _gs = _gOs.NewGame(_content);
                    break;
                case Data.Scenes.GameWon:
                    _gws.Update(gameTime);
                    if (_gws.NextLevel)
                    {
                        currentLevel++;
                        if(currentLevel < levels.Count)
                            _gs = _gws.NewLevel(_content, levels[currentLevel]);
                    }
                    if(currentLevel >= levels.Count)
                    {
                        Data.CurrentState = Data.Scenes.End;
                    }
                    break;
                case Data.Scenes.End:
                    _es.Update(gameTime);
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.Menu:
                    _ms.Draw(spriteBatch);
                    break;
                case Data.Scenes.Game:
                    _gs.Draw(spriteBatch);
                    break;
                case Data.Scenes.GameOver:
                    _gOs.Draw(spriteBatch);
                    break;
                case Data.Scenes.GameWon:
                    _gws.Draw(spriteBatch);
                    break;
                case Data.Scenes.End:
                    _es.Draw(spriteBatch);
                    break;
                default:
                    break;
            }
        }
    }
}
