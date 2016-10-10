using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Tetromino
{
    public Tetromino(Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        offset = gridblock.Width;
        angle = 0;
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
    public Color[,] matrix = new Color[4, 4];
    public Color blockColor = new Color(0, 204, 0);
     /*
    *  width of sprite for offset
    */
    float offset;
     /*
     * width in terms of grid elements
     */
    public int Width
    {
        get { return 4; }
    }
     /*
     * height in terms of grid elements
     */
    public int Height
    {
        get { return 4; }
    }
     /*
     * draws the grid on the screen
     */
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

    public void Clear()
    {
        int i = 0, j = 0;

        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                matrix[i, j] = Color.White;
            }
            j = 0;
        }
    }


}
