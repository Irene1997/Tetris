using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Tetromino
{
    Vector2 blockPosition;
    public Tetromino(Vector2 bPosition)
    {
        angle = 0;
        blockPosition = bPosition;
    }

     /*
     * the position of the tetris grid
     */
    
     /*
    *  matrix voor het tekenen van de grid 
    */
    public Color[,] block = new Color[4, 4];
    public Color blockColor;



    public void Update(GameTime gameTime, TetrisGrid grid)
    {
        int i, j;
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
               int x = (int)blockPosition.X + i;
               int y = (int)blockPosition.Y + j;
               if (x >= 0 && y >= 0)
               {
                    grid.SetBlock(x, y, block[i, j]);
               }
            }
            j = 0;
        }
    }


    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        
    }

    int angle; //0 = up, 1 = right, 2 = down, 3 = left

    void turnRight()
    {
        //if(there is space)
        //{
        if (angle < 4)
        {
            angle++;
        }
        else
        {
            angle = 0;
        }
        //}

        
    }
    
    public virtual void Up() { }
    public virtual void Right() { }
    public virtual void Down() { }
    public virtual void Left() { }

    public void Clear()
    {
        int i, j;

        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                block[i, j] = Color.White;
            }
            j = 0;
        }
    }


}
