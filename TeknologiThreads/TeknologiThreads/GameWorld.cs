using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using TeknologiThreads.Content;

namespace TeknologiThreads
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Create buildings
        private Goldmine goldMine;
        private Windmill windmill;
        private Townhall townhall;
        private Wonder wonder;

        // Create workers
        private WorkerManager workerManager;
        private Farmer farmer;
        private Miner miner;

        private SpriteFont font;
        private List<Button> _button;
        private Thread closegame;

        private bool WonderBuilt = false;

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create buildings
            goldMine = new Goldmine();
            windmill = new Windmill();
            townhall = new Townhall();
            wonder = new Wonder();

            workerManager = new WorkerManager(windmill, goldMine, townhall);

            // Load textures and set rectangles
            goldMine.texture = Content.Load<Texture2D>("goldmine");
            goldMine.rectangle = new Rectangle(300, 100, 150, 150);

            windmill.texture = Content.Load<Texture2D>("windmill");
            windmill.rectangle = new Rectangle(1200, 100, 150, 150);

            townhall.texture = Content.Load<Texture2D>("townhall");
            townhall.rectangle = new Rectangle(700, 700, 250, 250);

            wonder.texture = Content.Load<Texture2D>("wonder");
            wonder.rectangle = new Rectangle(650, 100, 750, 750);

            font = Content.Load<SpriteFont>("font");
            

            
            // Create buttons
            var randomButton = new Button(Content.Load<Texture2D>("MinerButton1"), Content.Load<SpriteFont>("File"))
            {
                Position = new Vector2(500, 900),
                Text = "",
            };

            randomButton.Click += RandomButton_Click;

            var wonderButton = new Button(Content.Load<Texture2D>("WonderButtonT1"), Content.Load<SpriteFont>("File"))
            {
                Position = new Vector2(1100, 900),
                Text= ""
            };

            wonderButton.Click += WonderButton_Click; 

            _button = new List<Button>()
            {
               randomButton,
               wonderButton
            };

        }

        private void WonderButton_Click(object sender, EventArgs e)
        {
            // Check if the townhall has enough gold to build the wonder
            if (townhall.Gold >= 250) 
            {
                // Set the wonder built to true
                WonderBuilt = true;

                townhall.Gold -= 250;

                // Start a new thread to wait a little before closing the game
                //closegame = new Thread(CloseGame);
                closegame.Start();
            }
        }

        //private void CloseGame()
        //{
        //    Thread.Sleep(6000);

        //    // Close all miner threads
        //    foreach (var miners in workerManager.MinerList)
        //    {
        //        miners.CloseThread(miners.miner);
        //    }

        //    // Close all farmer threads
        //    foreach (var farmer in workerManager.FarmerList)
        //    {
        //        farmer.CloseThread(farmer.farmer);
        //    }

        //    Exit();
        //}

        // Button to create a new miner
        private void RandomButton_Click(object sender, System.EventArgs e)
        {
            if (townhall.Grain >= 50 && workerManager.MinerList.Count < 5)
            {
                // Create a new miner
                Miner miner = new Miner(townhall, goldMine, workerManager);
                miner.texture = Content.Load<Texture2D>("orc");
                workerManager.Miners.Add(miner);
                townhall.Grain -= 50;
            }
        }

        protected override void Update(GameTime gameTime)
        {
           

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Check if the townhall has enough grain to create a new farmer automatically
            if (townhall.Grain >= 20 && workerManager.FarmerList.Count < 5)
            {
                Farmer farmer = new Farmer(windmill, townhall, workerManager);
                farmer.texture = Content.Load<Texture2D>("orc");
                workerManager.Farmers.Add(farmer);
                townhall.Grain -= 20;
            }

            foreach (var button in _button)
                button.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            _spriteBatch.Begin();

            _spriteBatch.Draw(goldMine.texture, goldMine.rectangle, Color.White);
            _spriteBatch.Draw(windmill.texture, windmill.rectangle, Color.White);
            _spriteBatch.Draw(townhall.texture, townhall.rectangle, Color.White);

            // Draw miners
            foreach (var miner in workerManager.MinerList)
            {
                _spriteBatch.Draw(miner.texture, miner.rectangle, Color.White);
            }

            // Draw farmers
            foreach (var farmer in workerManager.FarmerList)
            {
                _spriteBatch.Draw(farmer.texture, farmer.rectangle, Color.White);
            }

            // Draw information
            _spriteBatch.DrawString(font, "Gold: " + townhall.Gold, new Vector2(10, 10), Color.White);
            _spriteBatch.DrawString(font, "Grain: " + townhall.Grain, new Vector2(150, 10), Color.White);
            _spriteBatch.DrawString(font, "Farmers: " + workerManager.FarmerList.Count + "/5", new Vector2(300, 10), Color.White);
            _spriteBatch.DrawString(font, "Miners: " + workerManager.MinerList.Count + "/5", new Vector2(500, 10), Color.White);
            _spriteBatch.DrawString(font, "Workers Waiting: " + workerManager.workerWaiting, new Vector2(700, 10), Color.White);

            // Draw wonder
            if (WonderBuilt)
            {
                _spriteBatch.Draw(wonder.texture, wonder.rectangle, Color.White);
                _spriteBatch.DrawString(font, "You Won!!", new Vector2(650, 400), Color.White);

            }

            // Draw buttons
            foreach (var button in _button)
            {
                button.Draw(gameTime, _spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}