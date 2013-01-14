using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    class Button
    {
        Texture2D Texture;
        Vector2 Position;
        Rectangle Rectangle;
        bool down;
        public bool isClicked;

        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size;

        public Button(Texture2D newTexture, GraphicsDevice graphics)
        {
            Texture = newTexture;

            size = new Vector2(graphics.Viewport.Width / 8, graphics.Viewport.Height / 30);

        }


        public void Update(MouseState mouse)
        {
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)size.X, (int)size.Y);

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(Rectangle))
            {
                if (colour.A == 255)
                    down = false;
                if (colour.A == 0)
                    down = true;
                if (down)
                    colour.A += 3;
                else
                    colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed)
                    isClicked = true;

            }

            else if (colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }
        }

        public void SetPosition(Vector2 NewPosition)
        {
            Position = NewPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, colour);
        }
    }
}
