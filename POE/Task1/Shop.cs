using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    public class Shop
    {
        Weapon[] weaponArray;
        Random rand = new Random();
        Character buyer;

        public Shop(Character buyer)
        {
            this.buyer = buyer;

            weaponArray = new Weapon[3];
            int random1 = rand.Next(4);

            for (int i = 0; i < 3; i++)
            {
                weaponArray[i] = RandomWeapon();
            }
        }

        private Weapon RandomWeapon()
        {
            int random2 = rand.Next(4);
            if (random2 == 0)
            {
                MeleeWeapon newDagger = new MeleeWeapon(MeleeTypes.DAGGER);
                return newDagger;
            }
            else if (random2 == 1)
            {
                MeleeWeapon newLongsword = new MeleeWeapon(MeleeTypes.LONGSWORD);
                return newLongsword;
            }
            else if (random2 == 2)
            {
                RangedWeapon newRifle = new RangedWeapon(RangedTypes.RIFLE);
                return newRifle;
            }
            else
            {
                RangedWeapon newLongbow = new RangedWeapon(RangedTypes.LONGBOW);
                return newLongbow;
            }
        }

        public bool CanBuy(int index)
        {
            if (buyer.Purse >= weaponArray[index].Cost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Buy(int index)
        {
            buyer.Purse -= weaponArray[index].Cost;
            buyer.PickUp(weaponArray[index]);
        }

        public void RandomiseNewWeapon(int index)
        {
            weaponArray[index] = RandomWeapon();
        }

        public string DisplayWeapon(int num)
        {
            return $"Buy {weaponArray[num].WeaponName} ({weaponArray[num].Cost} Gold)";
        }

        public string BoughtWeapon(int num)
        {
            return $"{weaponArray[num].WeaponName} bought for ({weaponArray[num].Cost} gold!)";
        }
    }
}
