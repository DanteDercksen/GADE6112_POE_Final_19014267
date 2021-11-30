using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    public abstract class Tile
    {
        protected int x;
        public int X
        {
            get
            {
                return x;
            }
        }

        protected int y;
        public int Y
        {
            get
            {
                return y;
            }
        }

        protected TileType tileT;
        public TileType TileT
        {
            get
            {
                return tileT;
            }
        }

        protected Tile(int X, int Y, TileType TileT)
        {
            this.x = X;
            this.y = Y;
            this.tileT = TileT;
        }
    }

    public enum TileType
    {
        Hero,
        Enemy,
        Gold,
        Weapon,
        Obstacle,
        EmptyTile,
        Item
    }
}
