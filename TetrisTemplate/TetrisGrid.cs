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

    Random random;

    /*sprite for representing a single grid block*/
    Texture2D gridblock;

    /*the position of the tetris grid */
    Vector2 position;

    /*matrix voor het tekenen van de grid*/
    Color[,] matrix = new Color[12,20];

    /* width of sprite for offset */
    float offset;

    string[] tetrom = new string[7] { "J", "L", "O", "T", "I", "Z", "S" };
    string nowTetrom, nextTetrom = "J";

    /*width in terms of grid elements */
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
        
        for(i = 0; i < 12; i++)
        {
            for(j = 0; j < 20; j++)
            {
                matrix[i, j] = Color.White;
            }
            j = 0;
        }

        
    }
    //checks if a row is full, if so return true, else return false
    public bool RowFull(int y)
    {
        int x = 0;
        for (x = 0; x < 12; x++)
        {
             if (matrix[x, y] == Color.White)
             {
                return false;
             }
        }
        return true;
    }

    public string RandomBlock()
    {
        //this is how we will display the block on the side.

        nowTetrom = nextTetrom;
        return nowTetrom;

        //make random number from 0-6
        //nextTetrom = tetrom[random.Next(7)];

    }

    public Color GetMatrix(int i, int j)
    {
        if (i >= 0 && i <= 11 && j >= 0 && j <= 19)
        {
            return matrix[i, j];
        }
        else
        {
            return new Color(0, 204, 0);
        }
    }

    public void SetBlock(int x, int y, Color color)
    {
        if (x >= 0 && x <= 11 && y >= 0 && y <= 19)
        {
            matrix[x, y] = color;
        }
    }

    /*
     * draws the grid on the screen
     */
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        int i, j;
        position = new Vector2(0, 0);
    
        for (i = 0; i < 12; i++)
        {
            j = 0;
            position.X = i * offset;
            for (j = 0; j < 20; j++)
            {
                position.Y = j * offset;
                s.Draw(gridblock, position, null, this.GetMatrix(i, j), 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            }
            
        }
    }
}

