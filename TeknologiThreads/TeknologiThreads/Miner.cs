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
        private Semaphore MineSemaphore;
        private Semaphore TownhallSemaphore;
        public bool run = true;

        public Miner(Townhall townhall, Goldmine goldmine, WorkerManager workerManager)
        {
            this.rectangle = new Rectangle(700, 700, 100, 100);
            this.townhall = townhall;
            this.goldmine = goldmine;
            this.workerManager = workerManager;

            MineSemaphore = new Semaphore(0, 2);
            TownhallSemaphore = new Semaphore(0, 2);

            MineSemaphore.Release(2);
            TownhallSemaphore.Release(2);

            miner = new Thread(MinerWork);
            miner.IsBackground = true;
            miner.Start();
        }

        public void MinerWork()
        {
            // Miner work loop
            while (true && run)
            {
                // Move to goldmine
                MoveToRectangle(goldmine.rectangle);

                // Update worker waiting counter
                workerManager.workerWaiting++;

                // Wait for semaphore (other workers)
                MineSemaphore.WaitOne();

                // Update worker waiting counter

                workerManager.workerWaiting--;

                // Generate Gold from goldmine
                goldmine.GenerateGold(this);

                // "Work"
                Thread.Sleep(5000);
                
                // Release semaphore to allow other workers to work
                MineSemaphore.Release();
                
                // Move to townhall
                MoveToRectangle(townhall.rectangle);

                // Update worker waiting counter
                workerManager.workerWaiting++;

                // Wait for semaphore (other workers)
                TownhallSemaphore.WaitOne();

                // Update worker waiting counter
                workerManager.workerWaiting--;

                // Deliver gold to townhall
                townhall.lockTaken = true;
                townhall.DeliverGold(this.currentResources);
                this.currentResources = 0;
                Thread.Sleep(1000);
                townhall.lockTaken = false;

                // Release semaphore to allow other workers to work
                TownhallSemaphore.Release();

            }
        }

        // Close miner thread
        public void CloseThread(Thread miner)
        {
            run = false;
        }

        // Move miner to rectangle
        public void MoveToRectangle(Rectangle rectangle)
        {
            while (rectangle.Center != this.rectangle.Center)
            {
                if (rectangle.Center.X > this.rectangle.Center.X)
                {
                    this.rectangle.X += 1;
                    Thread.Sleep(1);
                }
                else 
                {
                    this.rectangle.X -= 1;
                    Thread.Sleep(1);
                }

                if (rectangle.Center.Y > this.rectangle.Center.Y)
                {
                    this.rectangle.Y += 1;
                    Thread.Sleep(1);
                }
                else 
                {
                    this.rectangle.Y -= 1;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
