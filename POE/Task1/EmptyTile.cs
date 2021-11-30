using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class EmptyTile : Tile
    {
        public EmptyTile(int X, int Y) : base(X, Y, TileType.EmptyTile)
        {
            
        }
    }
}
