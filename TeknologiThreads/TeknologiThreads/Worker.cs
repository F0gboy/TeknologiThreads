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
    internal class Worker : GameObject
    {
        public int Cost;
        public int resourceGain;
        public int speed;
        public int currentResources;

        public Worker()
        {
            
        }
    }
}
