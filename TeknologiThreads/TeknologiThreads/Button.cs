using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknologiThreads.Content
{
    public class Button
    {
        #region fields
        private MouseState _currentMouse;

        private SpriteFont _font;

        private bool _isHovering;

        private MouseState _previouseMouse;

        private Texture2D _buttonTexture;
        #endregion

        #region properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _buttonTexture.Width, _buttonTexture.Height);
            }
        }

        public string Text { get; set; }

        #endregion

    #region Methods

        public Button(Texture2D texture, SpriteFont font)
        {
            _buttonTexture = texture;

            _font = font;

            PenColour = Color.Black;
        }

        // Draw method for the button
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            // Change the colour of the button when hovering
            if (_isHovering)
            {
                colour = Color.Gray;
            }

            spriteBatch.Draw(_buttonTexture, Rectangle, colour);

            // Draw the text in the middle of the button
            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        // Update method for the button
        public void Update(GameTime gameTime)
        {
            _previouseMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            // Change the colour of the button when hovering
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previouseMouse.LeftButton == ButtonState.Pressed)
                {
                    if (Click != null)
                        Click(this, new EventArgs());
                    
                }
            }
        }

     #endregion
    }
}