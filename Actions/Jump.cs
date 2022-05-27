namespace AbsolsMask;

public class Jump : Action
{
    private int maxJumpTime = 30;
    public int GravidadeY { get; private set; } = 0;


    public Jump(Bitmap spritesheet, int[] spriteTime, Posicao posicao) : base(spritesheet, spriteTime)
    {
        prioridade = 4;
    }


    public override void RunAction(Posicao posicao, Direction direction)
    {

        switch (KeyPressManager.LastKey(Keys.Left, Keys.Right))
        {
            case Keys.Left:
                posicao.SpeedX = -4;
                break;

            case Keys.Right:
                posicao.SpeedX = 4;
                break;
        }

        posicao.SpeedY -= 2;

        if (KeyPressManager.LastKey(Keys.X) == null || posicao.TopDistance == 0)
            this.prioridade = -1;
    }


    public override void RenderActionSprite(Posicao posicao, Graphics g, Direction direction)
    {
        if (direction == Direction.Right)
            g.DrawImage(
                spritesheet,
                new Rectangle(posicao.X + posicao.Width / 2 - spriteWidth / 2, posicao.Bottom - spritesheet.Height + 1, spriteWidth, spritesheet.Height),
                new Rectangle(spriteWidth * currentSprite, 0, spriteWidth, spritesheet.Height),
                GraphicsUnit.Pixel
            );
        else
            g.DrawImage(
                spritesheet,
                new Rectangle(posicao.Right - posicao.Width / 2 + spriteWidth / 2, posicao.Bottom - spritesheet.Height + 1, -spriteWidth, spritesheet.Height),
                new Rectangle(spriteWidth * currentSprite, 0, spriteWidth, spritesheet.Height),
                GraphicsUnit.Pixel
            );

        spriteDelay++;

        if (spriteDelay < spriteTime[currentSprite])
            return;

        spriteDelay = 0;
        currentSprite++;

        if (currentSprite == spriteNum)
            currentSprite = 2;
    }

    public override Action Reset()
    {
        currentSprite = 0;
        spriteDelay = 0;
        prioridade = 4;
        return this;
    }
}
