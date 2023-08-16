using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core;
using My2DGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Displayers
{
    internal class HealthDisplayer : DisplayerBase
    {
        private float _timer;
        private int _lives;
        public HealthDisplayer(ContentManager content, int lives) : base()
        {
            _texture = content.Load<Texture2D>("Heart");
            _lives = lives;
            FillRectangles();
        }
        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            EndGameOnAmount(0, Data.States.GameOver);
        }
        private void FillRectangles()
        {
            int heartDistance = _texture.Width + 4;
            for (int i = 0; i < _lives; i++)
            {
                Rectangles.Add(new Rectangle(i * 30 + heartDistance, 20, 20, 20));
            }
        }
        public void TakeLife()
        {
            if (_timer > 0.7)
            {
                Rectangles.RemoveAt(Rectangles.Count -1);
                _timer = 0;
            }
        }

        public void AddLife()
        {
            _lives += 1;
            AddItem(new Vector2(Rectangles.Count * 30 + _texture.Width + 4, 20), 20);
        }
    }
}
