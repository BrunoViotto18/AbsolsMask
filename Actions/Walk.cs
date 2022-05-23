namespace AbsolsMask;

[Walk]
public class Walk : Action
{
    public Walk(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {

    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                posicao.SpeedX = -5;
                break;

            case Direction.Right:
                posicao.SpeedX = 5;
                break;
        }
        changeDirection = true;
    }
}
