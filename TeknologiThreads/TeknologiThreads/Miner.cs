using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TeknologiThreads
{
    internal class Miner : Worker
    {
        Townhall townhall;
        Goldmine goldmine;
        WorkerManager workerManager;
        public Thread miner;

        public Miner(Townhall townhall, Goldmine goldmine, WorkerManager workerManager)
        {
            this.rectangle = new Rectangle(700, 700, 100, 100);
            this.townhall = townhall;
            this.goldmine = goldmine;
            this.workerManager = workerManager;

            miner = new Thread(MinerWork);
            miner.Start();
        }
        public void MinerWork()
        {
            while (true)
            {
                // Move to goldmine
                MoveToRectangle(goldmine.rectangle);

                workerManager.workerWaiting++;
                lock (goldmine.DoorLock)
                {
                    workerManager.workerWaiting--;
                    goldmine.lockTaken = true;
                    // Generate Gold
                    goldmine.GenerateGold(this);

                    // "Work"
                    Thread.Sleep(5000);
                    goldmine.lockTaken = false;
                }

                // Move to townhall
                MoveToRectangle(townhall.rectangle);

                workerManager.workerWaiting++;
                lock (townhall.DoorLock)
                {
                    workerManager.workerWaiting--;
                    townhall.lockTaken = true;
                    townhall.DeliverGold(this.currentResources);
                    this.currentResources = 0;
                    Thread.Sleep(1000);
                    townhall.lockTaken = false;
                }
            }
        }

        public void CloseThread(Thread miner)
        {
            miner.IsBackground = true;
        }

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
