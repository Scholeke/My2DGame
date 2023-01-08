using Microsoft.Xna.Framework;
using My2DGame.Animations;
using My2DGame.Core;
using My2DGame.Core.Interfaces;
using My2DGame.Input;
using SharpDX.WIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2DGame.Managers
{
    internal class MovementManager
    {
        IInputReader _input;
        public MovementManager(IInputReader input)
        {
            _input = input;
        }

        public void Move(Hero hero)
        {
            switch (_input)
            {
                case KeyboardReader:
                    KeyboardMove(hero);
                    break;
                default:
                    break;
            }

        }


        private void KeyboardMove(Hero hero)
        {
            Vector2 direction = _input.ReadInput();
            direction = hero.CheckJump(direction);
            if (direction.X >= 1)
            {
                hero.Animation = hero.MovingRight;
            }
            if (direction.X <= -1)
            {
                hero.Animation = hero.MovingLeft;
            }
            if (direction.X == 0)
            {
                if (hero.Animation == hero.MovingLeft)
                    hero.Animation = hero.IdleLeft;
                else if (hero.Animation == hero.MovingRight)
                    hero.Animation = hero.IdleRight;
            }

            direction *= hero.Velocity;
            hero.Position += direction;
            hero.Rectangle = new Rectangle((int)hero.Position.X, (int)hero.Position.Y, 64, 64);
        }

    }
}
