using System;
using System.Collections.Generic;
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

        public void GenerateGrain(Farmer farmer)
        {
            farmer.currentResources += 10;
        }
    }
}
