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

    TetrisGrid grid;

    Tetromino tetromino;

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

        //tetromino = new grid.RandomBlock()(bPosition);
        tetromino = new S(bPosition);
    }

   

    public void Reset()
    {
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {

    }

    public void Update(GameTime gameTime, InputHelper inputHelper)
    {
        tetromino.Update(gameTime, grid, inputHelper);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        tetromino.Draw(gameTime, spriteBatch, block, grid);
        DrawText("Hello! It's me", Vector2.Zero, spriteBatch);
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
