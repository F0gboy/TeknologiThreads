using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TeknologiThreads
{
    internal class Building : GameObject
    {
        public int currentWorkers;
        public int maxWorkers = 5;
        public Object DoorLock = new Object();
        public bool lockTaken;
        public int TaskTime;

        public Building() 
        {
        
        }
    }
}
