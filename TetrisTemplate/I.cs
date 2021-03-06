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
        block[2, 0] = blockColor;
        block[2, 1] = blockColor;
        block[2, 2] = blockColor;
        block[2, 3] = blockColor;
    }

    public override void Right()
    {
        Clear();
        block[0, 2] = blockColor;
        block[1, 2] = blockColor;
        block[2, 2] = blockColor;
        block[3, 2] = blockColor;
    }

    public override void Down()
    {
        Up();
    }


    public override void Left()
    {
        Right();
    }
}



