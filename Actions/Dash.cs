using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolsMask;

public class Dash : Action
{
    public Dash(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        changeDirection = false;
    }


    public override void RunAction(Posicao posicao, Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                posicao.SpeedX = -10;
                break;

            case Direction.Right:
                posicao.SpeedX = 10;
                break;
        }
    }
}
