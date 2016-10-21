﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Menu
{
    public Menu(ContentManager Content, Texture2D b, SpriteFont font)
    {
        textfont = font;
        button = b;

        menuback = Content.Load<Texture2D>("Menu");
        keyboard = Content.Load<Texture2D>("Keyboard");
        turnRight = Content.Load<Texture2D>("TurnRight");
        turnLeft = Content.Load<Texture2D>("TurnLeft");
        left = Content.Load<Texture2D>("Left");
        right = Content.Load<Texture2D>("Right");
        down = Content.Load<Texture2D>("Down");
    }
    enum GameState    {Playing, GameOver, StartUp}
    Texture2D menuback, keyboard, button; 
    Texture2D turnRight, turnLeft, left, right, down;
    SpriteFont textfont;


    public bool ButtonPressed(InputHelper inputHelper)
    {
        Vector2 position = inputHelper.MousePosition;
        if (position.X >= 330 && position.X <= 390 && position.Y >= 320 && position.Y <= 380 && inputHelper.MouseLeftButtonPressed())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*draws the menu on the screen*/
    public void Draw(GameTime gameTime, GameState gameState, SpriteBatch s)
    {
        s.Draw(menuback, Vector2.Zero, Color.White);

        if(gameState == GameState.StartUp)
        { 
            DrawText("Welkom to Tetris", new Vector2(290, 0), s);
            DrawText("The basic controls are: ", new Vector2(265, 30), s);

            s.Draw(left, new Vector2(212, 82), Color.White);
            DrawText("Move to the left", new Vector2(365, 82), s);

            s.Draw(right, new Vector2(212, 132), Color.White);
            DrawText("Move to the right", new Vector2(365, 132), s);

            s.Draw(down, new Vector2(212, 182), Color.White);
            DrawText("Move down", new Vector2(365, 182), s);

            s.Draw(turnLeft, new Vector2(212, 232), Color.White);
            DrawText("Turn to the left", new Vector2(365, 232), s);

            s.Draw(turnRight, new Vector2(212, 282), Color.White);
            DrawText("Turn to the right", new Vector2(365, 282), s);

            s.Draw(keyboard, new Vector2(100, 390), Color.White);
        }
        else
        {
            DrawText("Game Over", new Vector2(290, 0), s);
            DrawText("The basic controls are: ", new Vector2(265, 30), s);
        }
        s.Draw(button, new Vector2(330, 320), null, Color.White, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0);
        DrawText("Play", new Vector2(340, 340), s);
    }
    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(textfont, text, positie, Color.Black);
    }
}
