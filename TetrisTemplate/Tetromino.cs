﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Tetromino
{
    public Vector2 blockPosition = new Vector2(13, 5);
    bool active = false;
    public double fallDelay;

    public Tetromino()
    {
        angle = 0;
        fallDelay = 300;
    }

    public Color[,] block = new Color[4, 4];    //creates the 2d array for the tetromino
    public Color blockColor;
    public double LastPressedDown;
    int angle; //0 = up, 1 = right, 2 = down, 3 = left

    public void Activate()
    {
        if (!active)
        {
            active = true;
            blockPosition = new Vector2(4, -1);
        }
    }

    public void Update(GameTime gameTime, TetrisGrid grid, GameWorld gameWorld, InputHelper inputHelper)
    {
        if (active)
        {
            //calculates the time between the tetromino automatically falling down based on the score
            fallDelay = 300f / Math.Pow(1.3f, gameWorld.GetScore() / 2000f);

            //moves the tetromino down if key pressed or timer says so
            if (inputHelper.KeyPressed(Keys.Down) || inputHelper.KeyPressed(Keys.S) || LastPressedDown >= fallDelay)
            {
                blockPosition.Y++;
                LastPressedDown = 0;
                //if the block does not collide
                if (!CanPlace(grid))
                {
                    blockPosition.Y--;
                    /*place tetromino in matrix and place next tetromino*/
                    PlaceBlock(grid);
                    gameWorld.AddScore(10); // up score
                    gameWorld.RandomBlock(); //create new block
                    gameWorld.PlayPlaced(); //play soundeffect
                    //check if a row is full, if so remove and up score
                    for (int i = 19; i >= 0; i--)
                    {
                        if (grid.RowFull(i))
                        {
                            //delete the row and move every row above one down
                            grid.EmptyRow(i);
                            gameWorld.AddScore(100);
                            i++;
                            gameWorld.PlayLineCleared();
                        }
                    }
                }
            }
            LastPressedDown += gameTime.ElapsedGameTime.TotalMilliseconds;

            // turns the tetromino to the left
            if (inputHelper.KeyPressed(Keys.Up, false) || inputHelper.KeyPressed(Keys.E, false))
            {
                TurnRight();
                if (!CanPlace(grid))
                {
                    TurnLeft();
                }
            }

            // turns the tetromino to the right
            if (inputHelper.KeyPressed(Keys.RightShift, false) || inputHelper.KeyPressed(Keys.Q, false))
            {
                TurnLeft();
                if (!CanPlace(grid))
                {
                    TurnRight();
                }
            }

            // moves the tetromino to the left
            if (inputHelper.KeyPressed(Keys.Left) || inputHelper.KeyPressed(Keys.A))
            {
                blockPosition.X--;
                if (!CanPlace(grid))
                {
                    blockPosition.X++;
                }
            }

            // moves the tetromino to the right
            if (inputHelper.KeyPressed(Keys.Right) || inputHelper.KeyPressed(Keys.D))
            {
                blockPosition.X++;
                if (!CanPlace(grid))
                {
                    blockPosition.X--;
                }
            }
        }
    }

    //return color of the block
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

    //places the block in the grid(on bottom)
    public void PlaceBlock(TetrisGrid grid)
    {
        int i, j;
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                int x = (int)blockPosition.X + i;
                int y = (int)blockPosition.Y + j;
                if (GetBlock(i, j) != Color.White)
                {
                    grid.SetBlock(x, y, GetBlock(i, j));
                }
            }
        }
        
    }

    //turns tetromino left
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

    //turns tetromino right
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

    //checks if no part of the tetromino and tetrisgrid are overlapping
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

    //clears the blockgrid so new one can be drawn(if turns, old blocks do not show)
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
