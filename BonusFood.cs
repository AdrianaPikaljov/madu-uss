using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{

    class BonusFood : Point
    {
        private DateTime createdTime;

        public BonusFood(int x, int y, char sym) : base(x, y, sym)
        {
            createdTime = DateTime.Now;
        }

        public bool IsExpired()
        {
            return (DateTime.Now - createdTime).TotalSeconds > 5;
        }
    }

}
