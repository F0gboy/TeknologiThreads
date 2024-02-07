using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TeknologiThreads
{
    internal class Townhall : Building
    {
        public int Gold;
        public int Grain = 20;

        public Townhall()
        {
            
        }

        public void GenerateMiner()
        {
            
        }

        public void GenerateFarmer() 
        {
            
        }
        public void DeliverGrain(int grainAmount)
        {
            Grain += grainAmount;
        }
        public void DeliverGold(int goldAmount)
        {
            Gold += goldAmount;
        }

        public Rectangle TownhallRectangle
        {
            get { return this.rectangle; }
        }
    }
}
