using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknologiThreads
{
    internal class Building : GameObject
    {
        public int currentWorkers;
        public int maxWorkers;
        public bool lockTaken;
        public int TaskTime;

        public Building() 
        {
        
        }
    }
}
