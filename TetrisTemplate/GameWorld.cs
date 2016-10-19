using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;


class GameWorld
{

    enum GameState
    {
        Playing, GameOver
    }


    int screenWidth, screenHeight;

    Random random;

    SpriteFont font;

    Texture2D block;

    GameState gameState;
    int score = 0;

    Tetromino nowTetrom, nextTetrom;

    TetrisGrid grid;

    InputHelper inputhelper;
    
    

    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();
        gameState = GameState.Playing;

        block = Content.Load<Texture2D>("block");
        font = Content.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid(block);
        inputhelper = new InputHelper();
       // RandomBlock();
        RandomBlock();
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
    }

    public void Reset()
    {
    }

   

    public void AddScore(int add)
    {
        score += add;
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {

    }

    public void Update(GameTime gameTime, InputHelper inputHelper)
    {
        nextTetrom.Update(gameTime, grid, this, inputHelper);
        nowTetrom.Update(gameTime, grid, this, inputHelper);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        nextTetrom.Draw(gameTime, spriteBatch, block, grid);
        nowTetrom.Draw(gameTime, spriteBatch, block, grid);
        DrawText("Hello! It's me", new Vector2(400,0), spriteBatch);
        DrawText("Score: " + score, new Vector2(400, 30), spriteBatch);
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
