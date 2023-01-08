using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Animations
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
        private double dt;

        public Animation()
        {
            frames = new List<AnimationFrame>();
            counter = 0;
            CurrentFrame = new AnimationFrame(new Rectangle(0, 0, 24, 24));
            dt = 0;
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            dt += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 10;
            if(dt >= 1d / fps)
            {
                counter++;
                dt = 0;
            }
            if (counter >= frames.Count)
            {
                counter = 0;
            }

        }

        public void GetFramesFromTextureProperties(int width, int height,
            int numberOfWidthSprites, int numberOfHeightSprites, int beginX)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

                for (int x = beginX; x <= beginX + width - widthOfFrame; x += widthOfFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, 0, widthOfFrame, heightOfFrame)));
                }

            CurrentFrame = frames[0];
        }

        public void GetFramesFromTexturePropertiesToLeft(int width, int height,
            int numberOfWidthSprites, int numberOfHeightSprites, int beginX)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            //for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            //{
                for (int x = beginX - widthOfFrame; x >= beginX - width + widthOfFrame; x -= widthOfFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, heightOfFrame, widthOfFrame, heightOfFrame)));
                }

            //}

            CurrentFrame = frames[0];
        }
    }
}
