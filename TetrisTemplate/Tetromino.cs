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

    public Color[,] block = new Color[4, 4];
    public Color blockColor;
    public double LastPressedDown;
    int angle; //0 = up, 1 = right, 2 = down, 3 = left

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



    public void turnRight(GameTime gameTime, InputHelper inputHelper)
    {
        if(inputHelper.KeyPressed(Keys.Up)/*and there is space*/)
        {
            if (angle == 0)
            {
                angle++;
                Right();
            }
            else if(angle == 1)
            {
                angle++;
                Down();
            }
            else if (angle == 2)
            {
                angle++;
                Left();
            }
            else if (angle == 3)
            {
                angle = 0;
                Up();
            }
        } 
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
