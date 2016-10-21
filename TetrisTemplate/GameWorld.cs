using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.Media;
using System;


class GameWorld
{

    enum GameState
    {
        Playing, GameOver, StartUp
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
    }

    int screenWidth, screenHeight;

    Random random;

    SpriteFont font;

    Texture2D block, menu;

    GameState gameState = GameState.GameOver;
    int score = 0;

    Tetromino nowTetrom, nextTetrom;

    TetrisGrid grid;

    InputHelper inputhelper;

    SoundEffect placed, lineCleared;
    
    

    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();

        block = Content.Load<Texture2D>("Blockk");
        menu = Content.Load<Texture2D>("Menu");
        font = Content.Load<SpriteFont>("SpelFont");
        placed = Content.Load<SoundEffect>("placed");
        lineCleared = Content.Load<SoundEffect>("linecleared");
        grid = new TetrisGrid(block);
        inputhelper = new InputHelper();
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
        if (inputHelper.KeyPressed(Keys.Space) && gameState == GameState.GameOver){
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
            DrawText("Hello! It's me", new Vector2(400, 0), spriteBatch);
            DrawText("Score: " + GetScore() + ", FallDelay: " + nowTetrom.fallDelay, new Vector2(400, 30), spriteBatch);
            nextTetrom.Draw(gameTime, spriteBatch, block, grid);
            nowTetrom.Draw(gameTime, spriteBatch, block, grid);
        }
        else
        {
            spriteBatch.Draw(menu, Vector2.Zero, Color.White);
            DrawText("Welkom to Tetris", new Vector2(400, 0), spriteBatch);
            DrawText("the basic controllers are: ", new Vector2(400, 30), spriteBatch);
            DrawText("left: move to the left", new Vector2(400, 50), spriteBatch);
            DrawText("right: move to the right", new Vector2(400, 70), spriteBatch);
            DrawText("down: move down", new Vector2(400, 90), spriteBatch);
            DrawText("up: turn to the left", new Vector2(400, 110), spriteBatch);
            DrawText("shift: turn to the right", new Vector2(400, 130), spriteBatch);
        }

        spriteBatch.End();    
    }

    /*
     * utility method for drawing text on the screen
     */
    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Blue);
    }

    public Random Random
    {
        get { return random; }
    }
}
