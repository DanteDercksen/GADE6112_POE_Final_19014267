using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    public abstract class Character : Tile
    {
        protected int purse = 0;
        public int Purse
        {
            get { return purse; }
            set { purse = value; }
        }

        protected int hp;
        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        protected int maxHP;
        public int MaxHP
        {
            get { return maxHP; }
        }
        protected int damage;

        protected Tile[] vision;
        public Tile[] Vision
        {
            get { return vision;  }
        }

        protected Weapon weaponObject;
        public Weapon WeaponObject
        {
            get { return weaponObject; }
            set { weaponObject = value; }
        }

        public Character(int X, int Y, TileType type) : base(X, Y, type)
        {
            vision = new Tile[4];

            if (this is Goblin)
            {
                MeleeWeapon g = new MeleeWeapon(MeleeTypes.DAGGER);
                Equip(g);
            }
            else if (this is Leader)
            {
                MeleeWeapon l = new MeleeWeapon(MeleeTypes.LONGSWORD);
                Equip(l);
            }
            else if (this is Hero)
            {
                MeleeWeapon bh = new MeleeWeapon(MeleeTypes.BARE_HANDS);
                Equip(bh);
            }
        }

        public virtual void Attack(Character target)
        {
            target.HP -= this.damage;
        }

        public bool isDead()
        {
            return hp <= 0;
        }

        public virtual bool CheckRange(Character target)
        {
            return DistanceTo(target) <= 1;
        }

        private int DistanceTo(Character target)
        {
            return Math.Abs(x - target.X) + Math.Abs(y - target.Y);
        }

        public void Move(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.UP: y -= 1; break;
                case MovementEnum.DOWN: y += 1; break;
                case MovementEnum.LEFT: x -= 1; break;
                case MovementEnum.RIGHT: x += 1; break;
            }
        }

        public void Setvision(Tile up, Tile down, Tile left, Tile right)
        {
            vision[0] = up;
            vision[1] = down;
            vision[2] = left;
            vision[3] = right;
        }

        public abstract MovementEnum ReturnMove(MovementEnum move = 0);

        public abstract override string ToString();

        public void PickUp(Item i)
        {
            if (i is Gold)
            {
                Gold n = (Gold)i;
                purse += n.GoldAmount;
            }
            else if (i is Weapon)
            {
                Weapon w = (Weapon)i;
                Equip(w);
            }
        }

        private void Equip(Weapon w)
        {
            WeaponObject = w;
            this.damage = w.Damage;
        }

    }
    public enum MovementEnum
    {
        NO_MOVEMENT,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    public enum AttackDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }


}
