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

        // Method to deliver grain to the townhall
        public void DeliverGrain(int grainAmount)
        {
            Grain += grainAmount;
        }

        // Method to deliver gold to the townhall
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
