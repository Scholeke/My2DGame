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

namespace My2DGame.Managers
{
    internal class GameStateManager : IComponent
    {
        private Dictionary<Data.States, State> _stateMap;
        private State _currentScene;
        public void LoadContent(ContentManager content)
        {
            _stateMap = new Dictionary<Data.States, State>
            {
                { Data.States.Menu, new MenuState() },
                { Data.States.Game, new GameState() },
                { Data.States.GameOver, new GameOverState() },
                { Data.States.GameWon, new GameWonState() },
                { Data.States.End, new EndState() }
            };
            _currentScene = _stateMap[Data.CurrentState];
            foreach (State s in _stateMap.Values)
            {
                s.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            _currentScene = _stateMap[Data.CurrentState];
            _currentScene.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _currentScene.Draw(spriteBatch);
        }
    }
}
