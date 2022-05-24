namespace AbsolsMask;

public class Run : Action
{
    public Run(Bitmap spritesheet, int[] spriteTime) : base(spritesheet, spriteTime)
    {
        this.prioridade = 2;
    }

    public override void RunAction(Posicao posicao, Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                posicao.SpeedX = -7;
                break;

            case Direction.Right:
                posicao.SpeedX = 7;
                break;
        }
        this.changeDirection = true;
        if (!KeyPressManager.KeysPressed.Contains(Keys.Right) && !KeyPressManager.KeysPressed.Contains(Keys.Left) || !KeyPressManager.KeysPressed.Contains(Keys.Z))
            this.prioridade = -1;
    }
}
