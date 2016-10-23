using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


    class Button
    {
        public Button(Texture2D b, SpriteFont font, Vector2 buttonP, string t)
        {
            button = b;
            textfont = font;
            buttonPosition = buttonP;
            text = t;

            textPosition.X = buttonPosition.X + (1.25f * button.Width) - (textfont.MeasureString(text).X / 2);
            textPosition.Y = buttonPosition.Y + (1.25f * button.Height) - (textfont.MeasureString(text).Y / 2);
        }

        Texture2D button;
        SpriteFont textfont;
        Vector2 buttonPosition, textPosition;
        string text;

        public bool ButtonPressed(InputHelper inputHelper)
        {
            Vector2 mousePosition = inputHelper.MousePosition;
            if (mousePosition.X >= buttonPosition.X && mousePosition.X <= (buttonPosition.X + 60) && mousePosition.Y >= buttonPosition.Y && mousePosition.Y <= (buttonPosition.Y + 60) && inputHelper.MouseLeftButtonPressed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(GameTime gameTime, GameWorld gameWorld, SpriteBatch s)
        {

            s.Draw(button, buttonPosition, null, Color.White, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0);
            gameWorld.DrawText(text, textPosition, s);
        }
    }

    

