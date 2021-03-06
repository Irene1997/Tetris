﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Media;
using System;


class GameWorld
{

    public enum GameState
    {
        Playing, GameOver, StartUp, Pause
    }

    GameState gameState = GameState.StartUp;
    int score = 0;
    int screenWidth, screenHeight;

    Tetromino nowTetrom, nextTetrom;
    TetrisGrid grid;
    Texture2D block, logo;
    SpriteFont font, smallfont;
    Menu menu;
    Button menuPlay, menuStop, pause, play, stop;
    InputHelper inputhelper;
    Random random;

    SoundEffect placed, lineCleared;
    Song song;

    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();

        block = Content.Load<Texture2D>("Blockk");
        font = Content.Load<SpriteFont>("Font");
        smallfont = Content.Load<SpriteFont>("SmallFont");
        logo = Content.Load<Texture2D>("KeizerPinguin");
        placed = Content.Load<SoundEffect>("placed");
        lineCleared = Content.Load<SoundEffect>("linecleared");
        song = Content.Load<Song>("song");

        MediaPlayer.Volume = 0.5f;
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Play(song);

        menuPlay = new Button(block, font, new Vector2(270, 315), "Play");
        menuStop = new Button(block, font, new Vector2(370, 315), "Stop");
        pause = new Button(block, font, new Vector2(400, 320), "Pause");
        play = new Button(block, font, new Vector2(480, 320), "Play");
        stop = new Button(block, font, new Vector2(560, 320), "Stop");

        grid = new TetrisGrid(block);
        inputhelper = new InputHelper();
        menu = new Menu(Content, block, font, menuPlay, menuStop);

        RandomBlock();
  
    }

    //sets the gamestate
    public void SetGameState(GameState state)
    {
        gameState = state;
    }

    //returns the gamestate
    public GameState GetGameState()
    {
        return gameState;
    }

    //plays sound when block hits bottom
    public void PlayPlaced()
    {
        placed.Play();
    }

    //plays sound when row is full and cleared
    public void PlayLineCleared()
    {
        lineCleared.Play();
    }

    //creates a random block
    public void RandomBlock()
    {
        //makes the block on the side the block that is falling
        nowTetrom = nextTetrom;
        
        //make random number from 0-6

        switch (random.Next(7))
        {
            case 0:
                nextTetrom = new J();
                break;
            case 1:
                nextTetrom = new L();
                break;
            case 2:
                nextTetrom = new O();
                break;
            case 3:
                nextTetrom = new T();
                break;
            case 4:
                nextTetrom = new I();
                break;
            case 5:
                nextTetrom = new Z();
                break;
            case 6:
                nextTetrom = new S();
                break;
            default:
                nextTetrom = new S();
                break;
        }

        //if there is nothing in nowTetrom(begin of the game) call self again
        if(nowTetrom == null)
        {
            RandomBlock();
        }
        //makes the nowTetrom active
        else
        {
            nowTetrom.Activate();
        }
        //if the new tetromino cannot be drawn on anew, player is gameover
        if (!nowTetrom.CanPlace(grid))
        {
            SetGameState(GameState.GameOver);
        }
    }

    //add points to score
    public void AddScore(int add)
    {
        score += add;
    }

    //return the current score
    public int GetScore()
    {
        return score;
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper, TetrisGame tetrisGame)
    {
        //exit if escape of stop button in menu of gameplay
        if (inputHelper.KeyPressed(Keys.Escape) || (menuStop.ButtonPressed(inputHelper) && (GetGameState() == GameState.GameOver || GetGameState() == GameState.StartUp)) || (stop.ButtonPressed(inputHelper) && (GetGameState() == GameState.Pause || GetGameState() == GameState.Playing)))
            tetrisGame.Exit();

        //pauses game
        if (pause.ButtonPressed(inputHelper))
            SetGameState(GameState.Pause);

        //starts the 
        if ((menuPlay.ButtonPressed(inputHelper) && (GetGameState() == GameState.GameOver || GetGameState() == GameState.StartUp)) || (play.ButtonPressed(inputHelper) && GetGameState() == GameState.Pause))
        {
            if (GetGameState() == GameState.GameOver)
            {
                grid.Clear();
                score = 0;
            }
            SetGameState(GameState.Playing);
        }
    }
    public void Update(GameTime gameTime, InputHelper inputHelper)
    {
        //only update game if player is playing
        if (GetGameState() == GameState.Playing)
        {
            nextTetrom.Update(gameTime, grid, this, inputHelper);
            nowTetrom.Update(gameTime, grid, this, inputHelper);
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        Vector2 drawPostionLine = new Vector2(360, 0);
        spriteBatch.Draw(logo, new Vector2(685, 450), null, Color.White, 0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
        spriteBatch.DrawString(smallfont, "Pinguin Producions", new Vector2(670, 570), Color.Black);

        //if not menu, draw the game stuff
        if (gameState == GameState.Playing || GetGameState() == GameState.Pause)
        {
            DrawText("Hello! It's Tetris!!", new Vector2(400, 30), spriteBatch);
            DrawText("Score: " + GetScore(), new Vector2(400, 90), spriteBatch);
            DrawText("Next:", new Vector2(400, 120), spriteBatch);
            spriteBatch.Draw(logo, new Vector2(685, 450), null, Color.White, 0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(smallfont, "Pinguin Producions", new Vector2(670, 570), Color.Black);

            nextTetrom.Draw(gameTime, spriteBatch, block, grid);
            nowTetrom.Draw(gameTime, spriteBatch, block, grid);

            play.Draw(gameTime, this, spriteBatch);
            pause.Draw(gameTime, this, spriteBatch);
            stop.Draw(gameTime, this, spriteBatch);
        }
        //if menu, draw menu stuff
        else
        {
            menu.Draw(gameTime, this, spriteBatch);
        }

        spriteBatch.End();    
    }

    //utility method for drawing text on the screen
    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Black);
    }

    public Random Random
    {
        get { return random; }
    }
}
