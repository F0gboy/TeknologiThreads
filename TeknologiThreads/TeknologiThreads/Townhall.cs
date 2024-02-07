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
        public int Gold = 80;
        public int Grain;

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
            Gold += grainAmount;
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
