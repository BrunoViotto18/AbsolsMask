namespace AbsolsMask;

public abstract class Entidade
{
    protected int maxHP;
    protected int hp;
    protected Posicao position;
    protected int gravidadeX;
    protected int gravidadeY;

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
        get => this.Y - this.Height / 2;
    }
    public int Right
    {
        get => this.X + this.Width / 2;
    }
    public int Bottom
    {
        get => this.Y + this.Height / 2;
    }
    public int Left
    {
        get => this.X - this.Height / 2;
    }

    // Construtor
    public Entidade(int hp, int maxHp, int X, int Y, int gravidadeY, int gravidadeX = 0)
    {
        this.hp = hp;
        this.maxHP = maxHp;
        this.position = new Posicao(X, Y);
        this.gravidadeX = gravidadeX;
        this.gravidadeY = gravidadeY;
    }

    public abstract void RenderSelf(Graphics g);
    //public abstract void CalculateMoviment(List<Bloco> blocos, List<Entidade> entidades);
    //private abstract void CalculateCollision(List<Bloco> blocos, List<Entidade> entidades);
}
