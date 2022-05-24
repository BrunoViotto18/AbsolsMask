﻿namespace AbsolsMask;

[Walk]
public class Walk : Action
{
    public Walk(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 1;
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                posicao.SpeedX = -4;
                break;

            case Direction.Right:
                posicao.SpeedX = 4;
                break;
        }
        this.changeDirection = true;
        if (!KeyPressManager.KeysPressed.Contains(Keys.Right) && !KeyPressManager.KeysPressed.Contains(Keys.Left))
            this.prioridade = -1;
    }
}
