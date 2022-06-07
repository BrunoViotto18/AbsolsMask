namespace AbsolsMask;

public class GoombaWalk : Action
{
    public GoombaWalk(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 1;
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                posicao.SpeedX = -2;
                break;

            case Direction.Right:
                posicao.SpeedX = 2;
                break;
        }
    }

    public override Action Reset(Posicao posicao)
    {
        prioridade = 1;
        currentSprite = 0;
        spriteDelay = 0;
        changeDirection = true;
        return this;
    }
}
