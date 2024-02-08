using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknologiThreads
{
    internal class Windmill : Building
    {
        public Windmill() 
        {
            
        }

        // Method to generate grain
        public void GenerateGrain(Farmer farmer)
        {
            farmer.currentResources += 10;
        }

        public Rectangle WindmillRectangle
        {
            get { return this.rectangle; }
        }
    }
}
