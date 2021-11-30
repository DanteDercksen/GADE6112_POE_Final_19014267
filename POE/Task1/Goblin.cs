using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class Goblin : Enemy
    {
        
        public Goblin(int X, int Y) : base(X, Y, 10, 10, 1)
        {
        }

        public override MovementEnum ReturnMove(MovementEnum move = 0)
        {
           int random1 = rand.Next(1, 5);

            int maxTries = 10;
            int tries = 0;
            
            while(vision[random1-1].TileT != TileType.EmptyTile && tries < maxTries)
            {
                random1 = rand.Next(1, 5);

                tries++;

                if(tries == maxTries)
                {
                    return MovementEnum.NO_MOVEMENT;
                }
            }

            return (MovementEnum)random1;
        }
    }
}
