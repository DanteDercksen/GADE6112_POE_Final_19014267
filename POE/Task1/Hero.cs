using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class Hero : Character
    {
        public Hero(int X, int Y, int hp) : base(X, Y, TileType.Hero)
        {
            this.damage = 2;
            this.hp = 20;
            this.maxHP = 20;

        }

        public override MovementEnum ReturnMove(MovementEnum move)
        {
            int direction = (int)move - 1;
            // check vision!
            if(vision[direction] == null)
            {
                return MovementEnum.NO_MOVEMENT;
            }
            if ((vision[direction].TileT == TileType.EmptyTile || vision[direction].TileT == TileType.Item))
            {
                return move;
            }
            return MovementEnum.NO_MOVEMENT;
        }

        //Q 3.2
        public override string ToString()
        {
            //if(WeaponObject == null)
            //{
            //    WeaponObject.WeaponName = "Bare Hands";
            //    WeaponObject.Damage = 2;
            //    WeaponObject.Range = 1;
            //}

            return $"Player Stats:\n" +
                $"HP: {hp}/{maxHP}\n" +
                $"Damage: {damage}\n[{X}, {Y}]";
        }
    }
}
