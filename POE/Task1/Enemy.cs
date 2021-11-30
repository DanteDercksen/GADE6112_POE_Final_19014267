using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    abstract class Enemy : Character
    {
        protected Random rand = new Random();

        public Enemy(int X, int Y, int HP, int MaxHP, int Damage) : base(X, Y, TileType.Enemy)
        {
            this.hp = HP;
            this.maxHP = MaxHP;
            this.damage = Damage;
        }
        public MovementEnum EnemyReturnMove(MovementEnum move)
        {
            if (this is Mage)
            { 
                return MovementEnum.NO_MOVEMENT; 
            }
            else
            {
                int direction = (int)move - 1;

                if (this.isDead())
                {
                    return MovementEnum.NO_MOVEMENT;
                }
                else if (vision[direction] != null && vision[direction].TileT == TileType.EmptyTile)
                {
                    return move;
                }
                return MovementEnum.NO_MOVEMENT;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType()} at [{X}, {Y}] ({damage})";
        }
    }
}
