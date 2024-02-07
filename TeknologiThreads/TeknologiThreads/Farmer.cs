﻿using Microsoft.Xna.Framework;
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
            while (true)
            {
                // Move to windmill
                MoveToRectangle(windmill.rectangle);

                workerManager.workerWaiting++;
                lock (windmill.DoorLock) 
                {
                    workerManager.workerWaiting--;
                    windmill.lockTaken = true;
                    // Generate grain
                    windmill.GenerateGrain(this);

                    // "Work"
                    Thread.Sleep(5000);
                    windmill.lockTaken = false;
                }

                // Move to townhall
                MoveToRectangle(townhall.rectangle);

                workerManager.workerWaiting++;
                lock (townhall.DoorLock)
                {
                    workerManager.workerWaiting--;
                    townhall.lockTaken = true;
                    townhall.DeliverGrain(this.currentResources);
                    this.currentResources = 0;
                    Thread.Sleep(1000);
                    townhall.lockTaken = false;
                }
            }
        }

        public void CloseThread(Thread farmer)
        {
            farmer.IsBackground = true;
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
                else 
                {
                    this.rectangle.X -= 1;
                    Thread.Sleep(5);
                }

                if (rectangle.Center.Y > this.rectangle.Center.Y)
                {
                    this.rectangle.Y += 1;
                    Thread.Sleep(5);
                }
                else 
                { 
                    this.rectangle.Y -= 1;
                    Thread.Sleep(5);
                }
            }
        }
    }
}
