using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class Obstacle : Tile
    {
        public Obstacle(int X, int Y) : base(X, Y, TileType.Obstacle)
        {
            
        }
    }
}
