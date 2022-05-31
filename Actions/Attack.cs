namespace AbsolsMask;

public class Attack : Action
{
    public Attack(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 5;
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        if (currentSprite % 2 == 1)
            currentSprite++;

        if (currentSprite == spriteNum-1)
            this.prioridade = -1;
    }

    public override Action Reset(Posicao posicao)
    {
        this.prioridade = 5;
        currentSprite = 0;
        spriteDelay = 0;
        return this;
    }
}
