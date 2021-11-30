using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    //SAFE

    [Serializable]
    class Gold : Item
    {
        private int goldAmount;
        public int GoldAmount
        {
            get { return goldAmount; }
        }

        static Random rand = new Random();
        public Gold(int X, int Y) : base (X, Y)
        {
            goldAmount = rand.Next(1, 6);
        }

        public override string ToString()
        {
            return "Gold";
        }
    }
}
