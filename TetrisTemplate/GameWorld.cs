using Microsoft.Xna.Framework;
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
        Playing, GameOver, StartUp
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    int screenWidth, screenHeight;

    Random random;

    SpriteFont font;

    Texture2D block, logo;

    GameState gameState = GameState.StartUp;
    int score = 0;

    Tetromino nowTetrom, nextTetrom;

    TetrisGrid grid;

    Menu menu;

    InputHelper inputhelper;

    SoundEffect placed, lineCleared;

    Song song;

    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();

        block = Content.Load<Texture2D>("Blockk");
        font = Content.Load<SpriteFont>("Font");
        logo = Content.Load<Texture2D>("KeizerPinguin");
        placed = Content.Load<SoundEffect>("placed");
        lineCleared = Content.Load<SoundEffect>("linecleared");
        song = Content.Load<Song>("song");
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Play(song);

        grid = new TetrisGrid(block);
        inputhelper = new InputHelper();
        menu = new Menu(Content, block, font);
        
        RandomBlock();
  
    }


    public void PlayPlaced()
    {
    placed.Play();
    }

    public void PlayLineCleared()
    {
        lineCleared.Play();
    }


    public void RandomBlock()
    {
        //this is how we will display the block on the side.

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

        if(nowTetrom == null)
        {
            RandomBlock();
        }
        else
        {
            nowTetrom.Activate();
        }

        if (!nowTetrom.CanPlace(grid))
        {
            GameOver();
        }
    }

    public void Reset()
    {
    }


    public void AddScore(int add)
    {
        score += add;
    }

    public int GetScore()
    {
        return score;
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        if (menu.ButtonPressed(inputHelper) && (gameState == GameState.GameOver || gameState == GameState.StartUp))
        {
            if (gameState == GameState.GameOver)
            {
                grid.Clear();
                score = 0;
            }
            gameState = GameState.Playing;
        }
    }
    public void Update(GameTime gameTime, InputHelper inputHelper)
    {
        if (gameState == GameState.Playing)
        {
            nextTetrom.Update(gameTime, grid, this, inputHelper);
            nowTetrom.Update(gameTime, grid, this, inputHelper);
        }
        HandleInput(gameTime, inputHelper);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        Vector2 drawPostionLine = new Vector2(360, 0);

        if (gameState == GameState.Playing)
        {
            DrawText("Hello! It's Tetris!!", new Vector2(400, 30), spriteBatch);
            DrawText("Score: " + GetScore(), new Vector2(400, 90), spriteBatch);
            DrawText("Next:", new Vector2(400, 120), spriteBatch);
            spriteBatch.Draw(logo, new Vector2(400, 400), Color.White); 
            nextTetrom.Draw(gameTime, spriteBatch, block, grid);
            nowTetrom.Draw(gameTime, spriteBatch, block, grid);
        }
        else
        {
            menu.Draw(gameTime, this, spriteBatch);
        }

        spriteBatch.End();    
    }

    /*
     * utility method for drawing text on the screen
     */
    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Black);
    }

    public Random Random
    {
        get { return random; }
    }
}
