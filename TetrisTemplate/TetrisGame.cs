using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Media;

class TetrisGame : Game
{
    SpriteBatch spriteBatch;
    InputHelper inputHelper;
    GameWorld gameWorld;

    [STAThread]
    static void Main(string[] args)
    {
        TetrisGame game = new TetrisGame();
        game.Run();
    }

    public TetrisGame()
    {        
        // initialize the graphics device
        GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
        this.IsMouseVisible = true;

        // set the directory where game assets are located
        this.Content.RootDirectory = "Content";
        
        // set the desired window size
        graphics.PreferredBackBufferWidth = 800;
        graphics.PreferredBackBufferHeight = 600;

        // create the input helper object
        inputHelper = new InputHelper();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // create the game world
        gameWorld = new GameWorld(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Content);
    }

    protected override void Update(GameTime gameTime)
    {
        inputHelper.Update(gameTime);
        gameWorld.HandleInput(gameTime, inputHelper, this);
        gameWorld.Update(gameTime, inputHelper);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        gameWorld.Draw(gameTime, spriteBatch);
    }


}

/*
     |\_  /\  _/|
     |{}\/{}\/{}|
     |__________|
     /##########\
    /#(.)#/\#(.)#\
   /#####/__\#####\
  |#######\/#######|
 /|################|\
/ |####/      \####| \
| |###|        |###| |
| |###|        |###| |
\_\###|________|###/_/
   /_\          /_\
Pingu�n Poductions
					*/

