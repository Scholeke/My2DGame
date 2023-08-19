using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using My2DGame.Blocks;
using My2DGame.Buffs;
using My2DGame.Core;
using My2DGame.Core.Interfaces;
using My2DGame.Enemies;
using My2DGame.PickupItems;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using IDrawable = My2DGame.Core.Interfaces.IDrawable;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace My2DGame.Levels
{
    internal abstract class Level : IGameObject
    {
        protected int blockSize = 45;
        public List<Block> Blocks { get; set; }
        public int[,] Gameboard { get; protected set; }
        public Texture2D _tileset;
        public ContentManager _content;
        public Texture2D Background { get; protected set; }
        public List<Enemy> Enemies { get; protected set; }
        public List<PickupItem> Items { get; protected set; }
        public bool IsFinished { get; set; } = false;
        public List<ICollidable> Collidables { get; protected set; }
        public List<IGameObject> Objects { get; set; }
        public List<ICollidable> RemovedObjects { get; set; }
        public List<IDrawable> Drawables { get; set; }

        public Level(ContentManager content)
        {
            _content = content;
            Blocks = new List<Block>();
            _tileset = _content.Load<Texture2D>("tileset");
            Enemies = new List<Enemy>();
            Items = new List<PickupItem>();
            Objects = new List<IGameObject>();
            RemovedObjects = new List<ICollidable>();
            Drawables = new List<IDrawable>();
            Background = content.Load<Texture2D>("forestandcave");
            Collidables = new List<ICollidable>();

        }
        
        public void Initialize()
        {
            CreateBlocks();
            Objects.AddRange(Enemies);
            Drawables.AddRange(Items);
            Drawables.AddRange(Blocks);
            Drawables.AddRange(Objects);
            foreach(var a in Drawables)
            {
                if(a is ICollidable c)
                {
                    Collidables.Add(c);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, new Rectangle(0, 0, Data.ScreenWidth, Data.ScreenHeight), Color.White);
            foreach (IDrawable item in Drawables)
            {
                item.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IGameObject o in Objects)
            {
                o.Update(gameTime);
            }
            foreach(ICollidable o in RemovedObjects)
            {
                if (RemovedObjects.Contains(o))
                {
                    Drawables.Remove((IDrawable)o);
                    Collidables.Remove(o);
                }
            }
            RemovedObjects.Clear();

        }
        public void CreateBlocks()
        {
            for (int l = 0; l < Gameboard.GetLength(0); l++)
            {
                for (int c = 0; c < Gameboard.GetLength(1); c++)
                {
                    if (Gameboard[l, c] == 1)
                    {
                        Blocks.Add(new GroundBlock(
                            new Rectangle(c * blockSize, l * blockSize, blockSize, blockSize),
                            Color.White,
                            _tileset,
                            new Rectangle(16, 0, 16, 16)));
                    }
                    if (Gameboard[l, c] == 2)
                    {
                        Blocks.Add(new WaterBlock(
                            new Rectangle(c * blockSize, l * blockSize, blockSize, blockSize),
                            Color.White,
                            _tileset));
                    }
                    if (Gameboard[l, c] == 3)
                    {
                        Blocks.Add(new GroundBlock(
                            new Rectangle(c * blockSize, l * blockSize, blockSize, blockSize),
                            Color.White,
                            _tileset,
                            new Rectangle(16, 32, 16, 16))); ;
                    }
                }
            }
        }
    }
}
