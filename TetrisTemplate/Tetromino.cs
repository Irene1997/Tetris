﻿using System;
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

    public void Update(GameTime gameTime, TetrisGrid grid, GameWorld gameWorld, InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Down) || inputHelper.KeyPressed(Keys.S) || LastPressedDown >= 300.0)
        {
            blockPosition.Y++;
            LastPressedDown = 0;
            if(!CanPlace(grid))
            {
                blockPosition.Y--;
                /*place tetromino in matrix and place next tetromino*/
                PlaceBlock(grid);
                gameWorld.RandomBlock();
                for(int i = 19; i < 0; i--)
                {
                    if (grid.RowFull(i))
                    {
                        //delete the row and move every row above one down
                        i++;
                    }
                }
            }
        }
        LastPressedDown += gameTime.ElapsedGameTime.TotalMilliseconds;

        if (inputHelper.KeyPressed(Keys.Up) || inputHelper.KeyPressed(Keys.E))
        {
            TurnRight();
            if(!CanPlace(grid))
            {
                TurnLeft();
            }
        }

        if (inputHelper.KeyPressed(Keys.RightShift) || inputHelper.KeyPressed(Keys.Q))
        {
            TurnLeft();
            if (!CanPlace(grid))
            {
                TurnRight();
            }
        }

        if (inputHelper.KeyPressed(Keys.Left) || inputHelper.KeyPressed(Keys.A))
        {
            blockPosition.X--;
            if (!CanPlace(grid))
            {
                blockPosition.X++;
            }
        }

        if (inputHelper.KeyPressed(Keys.Right) || inputHelper.KeyPressed(Keys.D))
        {
            blockPosition.X++;
            if (!CanPlace(grid))
            {
                blockPosition.X--;
            }
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

    public void PlaceBlock(TetrisGrid grid)
    {
        int i, j;
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                int x = (int)blockPosition.X + i;
                int y = (int)blockPosition.Y + j;
                if (GetBlock(i, j) != Color.White/* && x >= 0 && y >= 0  al in je SetBlock method beveiligd*/)
                {
                    grid.SetBlock(x, y, GetBlock(i, j));
                }
            }
        }
    }

    public void TurnLeft()
    {
        if (angle == 0)
        {
            angle = 3;
            Left();
        }
        else if (angle == 1)
        {
            angle--;
            Up();
        }
        else if (angle == 2)
        {
            angle--;
            Right();
        }
        else if (angle == 3)
        {
            angle--;
            Down();
        }
    }

    public void TurnRight()
    {
        if (angle == 0)
        {
            angle++;
            Right();
        }
        else if (angle == 1)
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

    public bool CanPlace(TetrisGrid grid)
    {
        int i, j;
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                if (GetBlock(i, j) != Color.White && grid.GetMatrix(i + (int)blockPosition.X, j + (int)blockPosition.Y) != Color.White)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void Draw(GameTime gameTime, SpriteBatch s, Texture2D gridblock, TetrisGrid grid)
    {
        float offset = gridblock.Width;
        Vector2 position = new Vector2(0, 0);

        int i, j;
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                int x = (int)blockPosition.X + i;
                int y = (int)blockPosition.Y + j;
                if (block[i, j] != Color.White && x >= 0 && y >= 0)
                {
                    position.X = x * offset;
                    position.Y = y * offset;
                    s.Draw(gridblock, position, null, block[i, j], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
                }
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
        }
    }


}
