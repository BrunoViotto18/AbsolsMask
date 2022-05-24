namespace AbsolsMask;

public class Jump : Action
{
    public Jump(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 2;
    }
}
