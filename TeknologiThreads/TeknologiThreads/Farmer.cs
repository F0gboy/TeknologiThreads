using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeknologiThreads
{
    internal class Farmer : Worker
    {
        Windmill windmill;
        Townhall townhall;

        public Farmer(Windmill windmill, Townhall townhall) 
        {
            this.rectangle = new Rectangle(700, 700, 100, 100);
            this.windmill = windmill;
            this.townhall = townhall;

            Thread farmer = new Thread(FarmerWork); 
            farmer.Start();
        }

        public void FarmerWork()
        {
            //walk to the windmill
            MoveToRectangle(windmill.rectangle);
            windmill.GenerateGrain(this);

            Thread.Sleep(5000);

            MoveToRectangle(townhall.rectangle);
        }

        public void MoveToRectangle(Rectangle rectangle)
        {
            while (rectangle.Center != this.rectangle.Center)
            {
                if (rectangle.Center.X > this.rectangle.Center.X)
                {
                    this.rectangle.X += 1;
                    Thread.Sleep(5);
                }
                else { this.rectangle.X -= 1; }

                if (rectangle.Center.Y > this.rectangle.Center.Y)
                {
                    this.rectangle.Y += 1;
                    Thread.Sleep(5);
                }
                else { this.rectangle.Y -= 1; }
            }
        }   
    }
}
