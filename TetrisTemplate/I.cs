﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class I : Tetromino
{
    public I() : base()
    {
        blockColor = Color.Cyan;
        Up();
    }

    public override void Up()
    {
        Clear();
        block[1, 0] = blockColor;
        block[1, 1] = blockColor;
        block[1, 2] = blockColor;
        block[1, 3] = blockColor;
    }

    public override void Right()
    {
        Clear();
        block[0, 1] = blockColor;
        block[1, 1] = blockColor;
        block[2, 1] = blockColor;
        block[3, 1] = blockColor;
    }

    public override void Down()
    {
        Clear();
        block[2, 0] = blockColor;
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
        block[2, 3] = blockColor;
    }


    public override void Left()
    {
        Clear();
        block[0, 2] = blockColor;
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
        block[3, 2] = blockColor;
    }
}



