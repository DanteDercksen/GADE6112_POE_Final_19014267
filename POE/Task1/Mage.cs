using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    //SAFE

    [Serializable]
    class Mage : Enemy
    {
        int x;
        int y;
        public Mage(int X, int Y) : base(X, Y, 5, 5, 5)
        {
            this.x = X;
            this.y = Y;
        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NO_MOVEMENT)
        {
            return move;
        }

        public override bool CheckRange(Character target)
        {
            for (int ty = -1; ty <= 1; ty++)
            {
                for (int tx = -1; tx <= 1; tx++)
                {
                    if (tx == 0 && ty == 0)
                    {
                        continue;
                    }

                    if (target.X == x + tx && target.Y == y + ty)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
