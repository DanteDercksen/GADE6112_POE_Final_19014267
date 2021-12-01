using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    enum RangedTypes
    {
        LONGBOW,
        RIFLE
    }

    [Serializable]
    class RangedWeapon : Weapon
    {
        public RangedWeapon(RangedTypes weaponType, int x = 0, int y = 0) : base(x, y)
        {
            if (weaponType == RangedTypes.RIFLE)
            {
                durability = 3;
                range = 3;
                damage = 5;
                cost = 7;
                weaponName = "Rifle";
            }
            else if (weaponType == RangedTypes.LONGBOW)
            {
                durability = 4;
                range = 2;
                damage = 4;
                cost = 6;
                weaponName = "Longbow";
            }
        }

        public override string ToString()
        {
            return weaponName;
        }
    }
}
