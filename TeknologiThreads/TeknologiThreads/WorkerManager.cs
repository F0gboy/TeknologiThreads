using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeknologiThreads
{
    internal class WorkerManager
    {
        public List<Farmer> Farmers = new List<Farmer>();
        public List<Miner> Miners = new List<Miner>();
        public int workerWaiting;

        public WorkerManager(Windmill windmill, Goldmine goldmine, Townhall townhall)
        {
            
        }

        public List<Farmer> FarmerList
        {
            get { return Farmers; }
        }

        public List<Miner> MinerList
        {
            get { return Miners; }
        }
        public int workersWaiting
        {
            get { return workerWaiting; }
        }
    }
}
