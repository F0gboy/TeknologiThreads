using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknologiThreads
{
    internal class Miner : Worker
    {
        Townhall townhall;
        Goldmine goldmine;

        public Miner(Townhall townhall, Goldmine goldmine)
        {
            this.townhall = townhall;
            this.goldmine = goldmine;
        }

        public void GenerateGold(Building building)
        {
        
        }

    }
}
