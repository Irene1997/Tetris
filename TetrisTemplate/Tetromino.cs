using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
    public double LastPressedDown;

    public void MoveDown(GameTime gameTime, InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Down) || LastPressedDown >= 300.0)
        {
            blockPosition.Y++;
            LastPressedDown = 0;
        }
        LastPressedDown += gameTime.ElapsedGameTime.TotalMilliseconds;

    }

    public void MoveRight(GameTime gameTime, InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Right))
        {
            blockPosition.X++;
        }
    }

    public void MoveLeft(GameTime gameTime, InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Left))
        {
            blockPosition.X--;
        }
    }

    public void Update(GameTime gameTime, TetrisGrid grid)
    {
        int i, j;
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
               int x = (int)blockPosition.X + i;
               int y = (int)blockPosition.Y + j;
               if (block[i,j] != Color.White && x >= 0 && y >= 0)
               {
                    grid.SetBlock(x, y, block[i, j]);
               }
            }
            j = 0;
        }
    }

public Color GetBlock(int i, int j)
    {
        if (i >= 0 && i <= 3 && j >= 0 && j <= 3)
        {
            return block[i, j];
        }
        else
        {
            return Color.White;
        }
    }

    /*
    int l, k;
        for (l = 0; l< 4; i++)
        {
            for (k = 0; k< 4; j++)
            {
               int x = (int)blockPosition.X + l;
               int y = (int)blockPosition.Y + k;
               if (x >= 0 && y >= 0)
               {
                    grid.SetBlock(x, y, block[i, j]);
               }
            }
            j = 0;
        }
    */
    public void Draw(GameTime gameTime, SpriteBatch s, Texture2D gridblock, TetrisGrid grid)
    {
        int i, j;
        int offset = 0;
        Vector2 position = new Vector2(0, 0);
        
        for (i = 0; i < 12; i++)
        {
            j = 0;
            position.X = i * offset;
            for (j = 0; j < 20; j++)
            {
                position.Y = j * offset;
                if block[i + position.X, j + position.Y] != Color.White)
                {
                    s.Draw(gridblock, position, null, grid.GetMatrix(i, j), 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
                }
            }

        }
    }

    int angle; //0 = up, 1 = right, 2 = down, 3 = left

    public void turnRight(GameTime gameTime, InputHelper inputHelper)
    {
        //if(there is space)
        //{
        if (inputHelper.KeyPressed(Keys.Up) && angle < 4)
        {
            angle++;
        }
        else if(inputHelper.KeyPressed(Keys.Up))
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
