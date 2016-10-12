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
        int i, j;
        
        for(i = 0; i < 20; i++)
        {
            for(j = 0; j < 12; j++)
            {
                matrix[i, j] = Color.White;
            }
            j = 0;
        }

        
    }

    public void SetBlockColour(int x, int y, Color color)
    {
        matrix[x, y] = color;



        /*still working on this*/
        /*
        Color[,] block = new Color[4, 4];
        int i, j;
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                isf (block[i,j] != Color.White)
                {
                    x = matrix.position.x + i;
                    y = matrix.position.y + j;
                    Tetrisgrid.SetBlockColour(x, y, block[i,j]);
                }
            }
            j = 0;
        }
        */



    }

    /*
     * draws the grid on the screen
     */
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        int i, j;
        position = new Vector2(0, 0);
    
        for (i = 0; i < 20; i++)
        {
            j = 0;
            position.Y = i * offset;
            for (j = 0; j < 12; j++)
            {
                position.X = j * offset;
                s.Draw(gridblock, position, null, matrix[i, j], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            }
            
        }
    }
}

