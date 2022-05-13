namespace AbsolsMask;

public abstract class Entidade
{
    protected int maxHP;
    protected int hp;
    protected Posicao position;

    // GET & SET
    public int X
    {
        get => this.position.X;
    }
    public int Y
    {
        get => this.position.Y;
    }

    public int Height
    {
        get => this.position.Height;
    }
    public int Width
    {
        get => this.position.Width;
    }

    public int Top
    {
        get => position.Top;
    }
    public int Right
    {
        get => position.Right;
    }
    public int Bottom
    {
        get => position.Bottom;
    }
    public int Left
    {
        get => position.Left;
    }

    // Construtor
    public Entidade(int hp, int maxHp, int X, int Y)
    {
        this.hp = hp;
        this.maxHP = maxHp;
        this.position = new Posicao(X, Y);
    }

    public void CalculateSelfMoviment(Bloco[,] blocos, Entidades entidades)
    {
        this.position.CalculateMoviment(blocos, entidades);
    }

    public abstract void RenderSelf(Graphics g);
}
