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
        WorkerManager workerManager;
        public Thread farmer;

        public Farmer(Windmill windmill, Townhall townhall, WorkerManager workerManager) 
        {
            this.rectangle = new Rectangle(700, 700, 100, 100);
            this.windmill = windmill;
            this.townhall = townhall;
            this.workerManager = workerManager;

            farmer = new Thread(FarmerWork); 
            farmer.Start();
        }

        public void FarmerWork()
        {
            // Farmer work loop
            while (true)
            {
                // Move to windmill
                MoveToRectangle(windmill.rectangle);

                // Update worker waiting counter
                workerManager.workerWaiting++;

                // Wait for Lock (other workers)
                lock (windmill.DoorLock) 
                {
                    // Update worker waiting counter
                    workerManager.workerWaiting--;
                    windmill.lockTaken = true;

                    // Generate grain for this worker
                    windmill.GenerateGrain(this);

                    // "Work"
                    Thread.Sleep(5000);
                    windmill.lockTaken = false;
                }

                // Move to townhall
                MoveToRectangle(townhall.rectangle);

                // Update worker waiting counter
                workerManager.workerWaiting++;

                // Wait for Lock (other workers)
                lock (townhall.DoorLock)
                {
                    workerManager.workerWaiting--;
                    townhall.lockTaken = true;

                    // Deliver grain to townhall
                    townhall.DeliverGrain(this.currentResources);

                    this.currentResources = 0;
                    Thread.Sleep(1000);
                    townhall.lockTaken = false;
                }
            }
        }

        // Method to close the thread
        public void CloseThread(Thread farmer)
        {
            farmer.IsBackground = true;
        }

        // Method to move the worker to a specific rectangle
        public void MoveToRectangle(Rectangle rectangle)
        {
            while (rectangle.Center != this.rectangle.Center)
            {
                if (rectangle.Center.X > this.rectangle.Center.X)
                {
                    this.rectangle.X += 1;
                    Thread.Sleep(2);
                }
                else 
                {
                    this.rectangle.X -= 1;
                    Thread.Sleep(2);
                }

                if (rectangle.Center.Y > this.rectangle.Center.Y)
                {
                    this.rectangle.Y += 1;
                    Thread.Sleep(2);
                }
                else 
                { 
                    this.rectangle.Y -= 1;
                    Thread.Sleep(2);
                }
            }
        }
    }
}
