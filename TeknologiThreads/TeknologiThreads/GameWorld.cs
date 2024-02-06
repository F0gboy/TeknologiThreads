using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknologiThreads
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Goldmine goldMine;
        private Windmill windmill;
        private Townhall townhall;

        private WorkerManager workerManager;
        private Farmer farmer;
        private Miner miner;

        private int gold = 100;

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

            goldMine = new Goldmine();
            windmill = new Windmill();
            townhall = new Townhall();
            workerManager = new WorkerManager(windmill, goldMine, townhall);

            goldMine.texture = Content.Load<Texture2D>("goldmine");
            goldMine.rectangle = new Rectangle(300, 100, 150, 150);

            windmill.texture = Content.Load<Texture2D>("windmill");
            windmill.rectangle = new Rectangle(1200, 100, 150, 150);

            townhall.texture = Content.Load<Texture2D>("townhall");
            townhall.rectangle = new Rectangle(700, 700, 250, 250);
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (gold >= 100)
            {
                Farmer farmer = new Farmer(windmill, townhall);
                farmer.texture = Content.Load<Texture2D>("orc");
                workerManager.Farmers.Add(farmer);
                gold -= 100;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            _spriteBatch.Draw(goldMine.texture, goldMine.rectangle, Color.White);
            _spriteBatch.Draw(windmill.texture, windmill.rectangle, Color.White);
            _spriteBatch.Draw(townhall.texture, townhall.rectangle, Color.White);

            foreach (var miner in workerManager.MinerList)
            {
                _spriteBatch.Draw(miner.texture, miner.rectangle, Color.White);
            }

            foreach (var farmer in workerManager.FarmerList)
            {
                _spriteBatch.Draw(farmer.texture, farmer.rectangle, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}