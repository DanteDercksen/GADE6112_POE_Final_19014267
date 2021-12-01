using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class Leader : Enemy
    {
        private Tile target;
        public Tile Target
        {
            get { return target; }
            set { target = value; }
        }

        public Leader(int x, int y) : base(x, y, 20, 20, 2)
        {
            //Q 3.4
            this.purse = 2;
        }

        public override MovementEnum ReturnMove(MovementEnum move = 0)
        {
            int temp;
            //HELP!
            if (this.x < target.X)
            {
                move = MovementEnum.DOWN;
            }
            else if (x > target.X)
            {
                move = MovementEnum.UP;
            }
            else if (y < target.Y)
            {
                move = MovementEnum.RIGHT;
            }
            else if (y > target.Y)
            {
                move = MovementEnum.LEFT;
            }

            return move;
        }
    }
}
