using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public override string ToString()
        {
            return $"Player Stats:\n" +
                $"HP: {hp}/{maxHP}\n" +
                $"Damage: {damage}\n" +
                $"Position: [{X}, {Y}]\n" +
                $"Current Weapon: {WeaponObject.WeaponName}\n" +
                $"Weapon Range: {WeaponObject.Range}\n" +
                $"Weapon Damage: {WeaponObject.Damage}\n" +
                $"Current Gold: {Purse}";
        }
    }
}
