using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TeknologiThreads.Content;

namespace TeknologiThreads
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Button> _button;

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            var randomButton = new Button(Content.Load<Texture2D>("MinerButton1"), Content.Load<SpriteFont>("File"))
            {
                Position = new Vector2(500, 900),
                Text = "",
            };

            randomButton.Click += RandomButton_Click;


          

            _button = new List<Button>()
            {
               randomButton 
            };

           
            
        }

        private void RandomButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(); 

            foreach (var button in _button)
            {
                button.Draw(gameTime, _spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}