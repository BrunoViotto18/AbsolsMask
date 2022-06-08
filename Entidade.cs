namespace AbsolsMask;

public abstract class Entidade
{
    protected int maxHP;
    protected int hp;
    protected ActionManager actionManager;

    // GET & SET
    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
            if (hp > maxHP)
                hp = maxHP;
            else if (hp <= 0)
                MessageBox.Show("Game Over");
        }
    }

    public int X
    {
        get => this.actionManager.X;
    }
    public int Y
    {
        get => this.actionManager.Y;
    }

    public int Height
    {
        get => this.actionManager.Height;
    }
    public int Width
    {
        get => this.actionManager.Width;
    }

    public int Top
    {
        get => actionManager.Top;
    }
    public int Right
    {
        get => actionManager.Right;
    }
    public int Bottom
    {
        get => actionManager.Bottom;
    }
    public int Left
    {
        get => actionManager.Left;
    }

    public int? HitboxDamage
    {
        get => actionManager.HitboxDamage;
    }


    // Construtor
    public Entidade(int hp, int maxHp, int X, int Y)
    {
        this.hp = hp;
        this.maxHP = maxHp;
        this.actionManager = new ActionManager(X, Y);
    }

    public virtual void CalculateSelfCollision(Entidades entidades)
    {
        var entidade = actionManager.CalculateEntityCollision(entidades.Inimigos.ToArray());

        if (entidade == null)
            return;

        if (entidade.HitboxDamage == null)
            return;

        Hp = Hp - (int)entidade.HitboxDamage;
    }

    public void CalculateSelfMoviment(Bloco[,] blocos, Entidades entidades)
    {
        this.actionManager.CalculateAction();
        this.actionManager.RunCurrentAction();
        this.actionManager.CalculateActionMoviment(blocos, entidades);
    }

    public void RenderAction(Graphics g)
    {
        this.actionManager.RenderCurrentAction(g);
    }
}
