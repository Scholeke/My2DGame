using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Core;
using My2DGame.Core.Interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Displayers
{
    internal abstract class DisplayerBase : IGameObject
    {
        public List<Rectangle> Rectangles { get; set; }
        protected Texture2D _texture;

        public DisplayerBase()
        {
            Rectangles = new List<Rectangle>();
        }

        public void AddItem(Vector2 pos1, int width)
        {
            Rectangles.Add(new Rectangle((int)pos1.X, (int)pos1.Y, width, width));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Rectangles.Count; i++)
            {
                spriteBatch.Draw(_texture, Rectangles[i], Color.White);
            }
        }

        public abstract void Update(GameTime gameTime);

        protected void EndGameOnAmount(int amount, Data.States scene)
        {
            if (Rectangles.Count == amount)
                Data.CurrentState = scene;
        }

    }
}
