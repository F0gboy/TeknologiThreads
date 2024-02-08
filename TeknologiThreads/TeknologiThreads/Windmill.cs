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
    internal class Windmill : Building
    {
        public Windmill() 
        {
            this.rectangle = new Rectangle(
                (int)(position.X - spriteSize.X / 2),
                (int)(position.Y - spriteSize.Y / 2),
                (int)spriteSize.X,
                (int)spriteSize.Y);
            
        }

        // Method to generate grain
        public void GenerateGrain(Farmer farmer)
        {
            farmer.currentResources += 10;
        }
    }
}
