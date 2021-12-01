using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    enum MeleeTypes
    {
        DAGGER,
        LONGSWORD,
        BARE_HANDS
    }

    [Serializable]
    class MeleeWeapon : Weapon
    {
        public MeleeWeapon(MeleeTypes weaponType, int x = 0, int y = 0) : base(x, y)
        {
            if(weaponType == MeleeTypes.DAGGER)
            {
                durability = 10;
                damage = 3;
                range = 1;
                cost = 3;
                weaponName = "Dagger";
            }
            else if (weaponType == MeleeTypes.LONGSWORD)
            {
                durability = 6;
                damage = 4;
                range = 1;
                cost = 5;
                weaponName = "Longsword";
            }
            else if(weaponType == MeleeTypes.BARE_HANDS)
            {
                damage = 2;
                range = 1;
                weaponName = "Bare Hands";
            }
            
        }
        public override string ToString()
        {
            return weaponName;
        }
    }
}
