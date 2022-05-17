namespace AbsolsMask;

public class Action
{
    private Bitmap spritesheet;
    private int speriteNum;
    private int[] spriteTime;

    public Action(Bitmap spritesheet, int spriteNum, int[] spriteTime)
    {
        this.spritesheet = spritesheet;
        this.speriteNum = spriteNum;
        this.spriteTime = spriteTime;
    }

    public void RunAction(Posicao posicao)
    {

    }

    public void RenderActionSprite(Posicao posicao, Graphics g)
    {

    }
}
