namespace AbsolsMask;

public class Idle : Action
{
    public Idle(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 0;
    }
}
