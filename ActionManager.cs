namespace AbsolsMask;
public class ActionManager
{
    private Action currentAction;
    private Posicao posicao;
    private Direction direcao;
    private BuffsDebuffs buffDebuff;
    private List<Action> actions = new List<Action>();

    public ActionManager(Posicao posicao, Direction direcao, BuffsDebuffs buffDebuff, List<Action> actions){
        this.posicao = posicao;
        this.direcao = direcao;
        this.buffDebuff = buffDebuff;
        this.actions = actions;
    }

    //Gets de posicao
    public int X
    {
        get => posicao.X;
    }
    public int Y
    {
        get => posicao.Y;
    }

    public int Height
    {
        get => posicao.Height;
    }
    public int Width
    {
        get => posicao.Width;
    }

    public int Top
    {
        get => posicao.Top;
    }
    public int Bottom
    {
        get => posicao.Bottom;
    }
    public int Right
    {
        get => posicao.Right;
    }
    public int Left
    {
        get => posicao.Left;
    }

    
    public void CalculateAction()
    {

    }
}