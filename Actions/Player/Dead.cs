namespace AbsolsMask;

public class Dead : Action
{
    public Dead(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 7;
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {

    }

    public override Action Reset(Posicao posicao)
    {
        this.prioridade = 7;
        currentSprite = 0;
        spriteDelay = 0;
        return this;
    }
}
