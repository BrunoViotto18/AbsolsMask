namespace AbsolsMask;

public struct Entidades
{
    private Entidade player;
    private List<Entidade> inimigos;
    private Entidade? boss;
    private List<Entidade> particulas;

    public Entidade Player
    {
        get => player;
        set
        {
            if (value.GetType() != new Player(0, 0, 0, 0).GetType())
                return;

            player = value;
        }
    }

    public List<Entidade> Inimigos
    {
        get => inimigos;
    }

    public Entidade? Boss
    {
        get => boss;
    }

    public List<Entidade> Particulas
    {
        get => particulas;
    }

    public Entidades(Player player)
    {
        this.player = player;
        this.inimigos = new List<Entidade>();
        this.boss = null;
        this.particulas = new List<Entidade>();
    }

    public void addEnemy(params Entidade[] enemies)
    {
        foreach (var inimigo in enemies)
            inimigos.Add(inimigo);
    }
}

