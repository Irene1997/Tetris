using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;

/*
 * A class for representing the game world.
 */
class GameWorld
{
    /*
     * enum for different game states (playing or game over)
     */
    enum GameState
    {
        Playing, GameOver
    }

    /*
     * screen width and height
     */
    int screenWidth, screenHeight;

    /*
     * random number generator
     */
    Random random;

    /*
     * main game font
     */
    SpriteFont font;

    /*
     * sprite for representing a single tetris block element
     */
    Texture2D block;
    Vector2 bPosition;

    /*
     * the current game state
     */
    GameState gameState;

    /*
     * the main playing grid
     */
    TetrisGrid grid;

    Tetromino tetromino;

    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();
        gameState = GameState.Playing;

        block = Content.Load<Texture2D>("block");
        font = Content.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid(block);

        //hier moet nog een random plaats benoemd worden
        bPosition = new Vector2(-1, -1);

        tetromino = new J(bPosition);
    }

    public void Reset()
    {
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        tetromino.MoveDown(gameTime, inputHelper);
        tetromino.MoveRight(gameTime, inputHelper);
        tetromino.MoveLeft(gameTime, inputHelper);
    }

    public void Update(GameTime gameTime)
    {
        tetromino.Update(gameTime, grid);
        tetromino.Up();
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
