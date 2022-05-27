namespace AbsolsMask;

public class Action
{
    protected Bitmap spritesheet;
    protected int spriteNum;
    protected int spriteWidth;
    protected int[] spriteTime;
    protected bool changeDirection;
    protected int prioridade;

    protected int tempGravidadeX;
    protected int tempGravidadeY;


    protected int currentSprite = 0;
    protected int spriteDelay = 0;


    public bool ChangeDirection
    {
        get => changeDirection;
    }
    public int Prioridade
    {
        get => prioridade;
    }


    public Action(Bitmap spritesheet, int[] spriteTime)
    {
        this.spritesheet = spritesheet;
        this.spriteTime = spriteTime;
        this.spriteNum = spriteTime.Length;
        this.spriteWidth = spritesheet.Width / spriteNum;
        this.changeDirection = true;
    }


    public virtual void RunAction(Posicao posicao, Direction direction)
    {
        changeDirection = true;
    }

    public virtual void RenderActionSprite(Posicao posicao, Graphics g, Direction direction)
    {
        if (direction == Direction.Right)
            g.DrawImage(
                spritesheet,
                new Rectangle(posicao.X + posicao.Width / 2 - spriteWidth / 2, posicao.Bottom - spritesheet.Height+1, spriteWidth, spritesheet.Height),
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
            currentSprite = 0;
    }

    public virtual Action Reset()
    {
        changeDirection = true;
        return this;
    }
}
