using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core;
using My2DGame.Levels;
using My2DGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Displayers
{
    internal class CoinDisplayer : DisplayerBase
    {
        public CoinDisplayer(ContentManager content) : base()
        {
            _texture = content.Load<Texture2D>("coin");
        }

        public override void Update(GameTime gameTime)
        {
            if(LevelManager.GetInstance().CurrentLevel is Level2)
            {
                EndGameOnAmount(3, Data.States.End);
            }
            else
            {
                EndGameOnAmount(3, Data.States.GameWon);
            }
            
        }

        public void AddCoin()
        {
            AddItem(new Vector2(Rectangles.Count * 40 + 1300, 20), 40);
        }
    }
}
