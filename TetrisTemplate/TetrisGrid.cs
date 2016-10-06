using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * a class for representing the Tetris playing grid
 */
class TetrisGrid
{
    public TetrisGrid(Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        offset = gridblock.Width;
        this.Clear();
    }

    /*
     * sprite for representing a single grid block
     */
    Texture2D gridblock;

    /*
     * the position of the tetris grid
     */
    Vector2 position;

    /*
    *  matrix voor het tekenen van de grid 
    */
    Color[,] matrix = new Color[20,12];

    /*
    *  width of sprite for offset
    */
    float offset;

    /*
     * width in terms of grid elements
     */
    public int Width
    {
        get { return 12; }
    }

    /*
     * height in terms of grid elements
     */
    public int Height
    {
        get { return 20; }
    }

    /*
     * clears the grid
     */
    public void Clear()
    {
        int i = 0, j = 0;
        while (i < 20 && j < 12)
        {
            matrix[i, j] = Color.White;
            j++;
            if(j == 12)
            {
                j = 0;
                i++;
            }
        }
    }

    /*
     * draws the grid on the screen
     */
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        int i = 0, j = 0;
        position = new Vector2(0,0);
        while (i < 20 && j < 12)
        {
            position.X = j * offset;
            s.Draw(gridblock, position, null, matrix[i, j], 0.0f, Vector2.Zero,1.0f, SpriteEffects.None, 0);

            j++;

            if (j == 12)
            {
                j = 0;
                i++;
                position.Y = i * offset;
            }
        }
    }
}

