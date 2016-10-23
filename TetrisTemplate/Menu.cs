using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Menu
{
    public Menu(ContentManager Content, Texture2D b, SpriteFont font, Button p, Button s)
    {
        textfont = font;
        largefont = Content.Load<SpriteFont>("LargeFont");
        button = b;
        menuPlay = p;
        menuStop = s;

        menuback = Content.Load<Texture2D>("Menu");
        keyboard = Content.Load<Texture2D>("Keyboard");
        turnRight = Content.Load<Texture2D>("TurnRight");
        turnLeft = Content.Load<Texture2D>("TurnLeft");
        left = Content.Load<Texture2D>("Left");
        right = Content.Load<Texture2D>("Right");
        down = Content.Load<Texture2D>("Down");
    }

    Texture2D menuback, keyboard, button; 
    Texture2D turnRight, turnLeft, left, right, down;
    SpriteFont textfont, largefont;
    Button menuPlay, menuStop;
    
    //draws the menu on the screen
    public void Draw(GameTime gameTime, GameWorld gameWorld, SpriteBatch s)
    {
        s.Draw(menuback, Vector2.Zero, Color.White);

        //Startup menu
        if (gameWorld.GetGameState() == GameWorld.GameState.StartUp)
        {
            gameWorld.DrawText("Welkom to Tetris", new Vector2(290, 5), s);
            gameWorld.DrawText("The basic controls are: ", new Vector2(265, 35), s);

            s.Draw(left, new Vector2(212, 82), Color.White);
            gameWorld.DrawText("Move to the left", new Vector2(365, 80), s);

            s.Draw(right, new Vector2(212, 132), Color.White);
            gameWorld.DrawText("Move to the right", new Vector2(365, 130), s);

            s.Draw(down, new Vector2(212, 182), Color.White);
            gameWorld.DrawText("Move down", new Vector2(365, 180), s);

            s.Draw(turnLeft, new Vector2(212, 232), Color.White);
            gameWorld.DrawText("Turn to the left", new Vector2(365, 230), s);

            s.Draw(turnRight, new Vector2(212, 282), Color.White);
            gameWorld.DrawText("Turn to the right", new Vector2(365, 280), s);

            s.Draw(keyboard, new Vector2(100, 400), Color.White);
        }
        //Gameover menu
        else if (gameWorld.GetGameState() == GameWorld.GameState.GameOver)
        {
            s.DrawString(largefont, "Game Over", new Vector2(250, 50), Color.Black);
            gameWorld.DrawText("Score: " + gameWorld.GetScore(), new Vector2(300, 150), s);
            gameWorld.DrawText("Press Play to try again", new Vector2(265, 230), s);
        }

        menuPlay.Draw(gameTime, gameWorld, s);
        menuStop.Draw(gameTime, gameWorld, s);
    }
  
}

