using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TeknologiThreads
{
    internal class Goldmine : Building
    {
        public Goldmine()
        {
            
        }

        public void GenerateGold(Miner miner)
        {
            miner.currentResources += 20;
        }
        public Rectangle GoldMineRectangle
        {
            get { return this.rectangle; }
        }
    }
}
