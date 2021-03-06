﻿using System;
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
        offset = gridblock.Width;
        this.Clear();
    }

    //sprite for representing a single grid block
    Texture2D gridblock;

    //the position of each block in the tetris grid 
    Vector2 position;

    //matrix voor het tekenen van de grid
    Color[,] matrix = new Color[12,20];

    //width of sprite for offset 
    float offset;

    //clears the grid
    public void Clear()
    {
        int i, j;
        
        for(i = 0; i < 12; i++)
        {
            for(j = 0; j < 20; j++)
            {
                matrix[i, j] = Color.White;
            }
        }
  
    }

    //checks if a row is full, if so return true, else return false
    public bool RowFull(int y)
    {
        for (int x = 0; x < 12; x++)
        {
             if (matrix[x, y] == Color.White)
             {
                return false;
             }
        }
        return true;
    }

    //empties a row by moving row above onto this one
    public void EmptyRow(int y)
    {
        for (int i = y; i > 0; i--)
        { 
            for (int x = 0; x < 12; x++)
            {
                matrix[x, i] = GetMatrix(x, i - 1);
            }
        }
    }

    //returns color of a matrix position
    public Color GetMatrix(int i, int j)
    {
        if (i >= 0 && i <= 11 && j >= 0 && j <= 19)
        {
            return matrix[i, j];
        }
        else if(i > 11 || i < 0 || j > 19)
        {
            return new Color(0, 204, 0);
        }
        else
        {
            return Color.White;
        }
    }

    //sets the block in the grid(on bottom)
    public void SetBlock(int x, int y, Color color)
    {
        if (x >= 0 && x <= 11 && y >= 0 && y <= 19)
        {
            matrix[x, y] = color;
        }
    }


    //draws the grid on the screen
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        int i, j;
        position = new Vector2(0, 0);
    
        for (i = 0; i < 12; i++)
        {
            position.X = i * offset;
            for (j = 0; j < 20; j++)
            {
                position.Y = j * offset;
                s.Draw(gridblock, position, null, this.GetMatrix(i, j), 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            }
            
        }
    }
}

