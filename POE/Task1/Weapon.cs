using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    public abstract class Weapon : Item
    {
        protected int damage;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        protected int range;
        public virtual int Range
        {
            get { return range; }
            set { range = value; }
        }

        protected int durability;
        public int Durability
        {
            get { return durability; }
        }

        protected int cost;
        public int Cost
        {
            get { return cost; }
        }

        protected string weaponName;
        public string WeaponName
        {
            get { return weaponName; }
            set { weaponName = value; }
        }

        public Weapon(int x = 0, int y = 0) : base(x, y)
        {
            this.tileT = TileType.Weapon;
        }
    }
}
