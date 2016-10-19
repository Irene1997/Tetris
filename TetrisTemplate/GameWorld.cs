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
    Vector2 bPosition;

    GameState gameState;
    int score = 0;

    TetrisGrid grid;

    Tetromino tetromino;
    string nowTetrom, nextTetrom;

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
        bPosition = new Vector2(4, -1);
        RandomBlock();
        
    }

   

    public void Reset()
    {
    }

    public void RandomBlock()
    {
        //this is how we will display the block on the side.

        nowTetrom = nextTetrom;

        //make random number from 0-6
        //nextTetrom = tetrom[random.Next(7)];
 
        switch (random.Next(7))
        {
            case 0:
                tetromino = new J(bPosition);
                break;
            case 1:
                tetromino = new L(bPosition);
                break;
            case 2:
                tetromino = new O(bPosition);
                break;
            case 3:
                tetromino = new T(bPosition);
                break;
            case 4:
                tetromino = new I(bPosition);
                break;
            case 5:
                tetromino = new Z(bPosition);
                break;
            case 6:
                tetromino = new S(bPosition);
                break;
            default:
                tetromino = new S(bPosition);
                break;
        }

      
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
        tetromino.Update(gameTime, grid, this, inputHelper);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        tetromino.Draw(gameTime, spriteBatch, block, grid);
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
