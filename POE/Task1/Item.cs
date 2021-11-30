using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    //SAFE
    
    [Serializable]
    abstract public class Item : Tile
    {
        public Item(int X, int Y): base(X, Y, TileType.Item)
        {

        }

        public abstract override string ToString();
    }
}
