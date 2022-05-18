namespace AbsolsMask;

public class Action
{
    protected Bitmap spritesheet;
    protected int spriteNum;
    protected int[] spriteTime;
    protected int currentSprite;
    protected int spriteDelay;

    public Action(Bitmap spritesheet, int spriteNum, int[] spriteTime)
    {
        this.spritesheet = spritesheet;
        this.spriteNum = spriteNum;
        this.spriteTime = spriteTime;
    }

    public virtual void RunAction(Posicao posicao, Direction direction)
    {

    }

    public virtual void RenderActionSprite(Posicao posicao, Graphics g, Direction direction)
    {
        currentSprite = 0;
        spriteDelay = 0;

        while (true)
        {
            while (spriteDelay < spriteTime[currentSprite])
            {
                if (direction == Direction.Right)
                    g.DrawImage(
                        spritesheet,
                        new Rectangle(posicao.X, posicao.Y, posicao.Width, posicao.Height),
                        new Rectangle(spritesheet.Width / spriteNum - 1 * currentSprite, 0, spritesheet.Width / spriteNum, spritesheet.Height),
                        GraphicsUnit.Pixel
                    );
                else
                    g.DrawImage(
                        spritesheet,
                        new Rectangle(posicao.Right, posicao.Top, -posicao.Width, posicao.Height),
                        new Rectangle(spritesheet.Width / spriteNum - 1 * currentSprite, 0, spritesheet.Width / spriteNum, spritesheet.Height),
                        GraphicsUnit.Pixel
                    );
                return;
            }

            spriteDelay = 0;
            currentSprite++;


            if (currentSprite == spriteNum)
                currentSprite = 0;
        }
    }
}
