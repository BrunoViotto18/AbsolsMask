namespace AbsolsMask;

public class Sala
{
    private Bitmap salaImage;
    private Bitmap salaBackground;
    private Bloco[,] blocos;
    private Entidades entidades;

    private TipoSala tipoSala;
    private List<Entradas> entradas;
    private TamanhoSala tamanhoSala;


    // GET & SET
    public int getSalaWidth()
        => blocos.GetLength(0) * 32;

    public int getSalaHeight()
        => blocos.GetLength(1) * 32;

    public Entidade Player
    {
        get => this.entidades.Player;
    }
    // Construtor
    public Sala()
    {
        this.entidades = new Entidades();
        this.entidades.Player = new Player(10, 10, 150, 150);
        this.entidades.Inimigos.Append(new Goomba(10, 10, 150, 150));
        //this.entidades.player = new Player(550, 100);
        this.salaImage = Properties.Salas.Teste;
        this.salaBackground = Properties.Background.Trevisan;
        buildRoom();
    }


    /* Métodos de construtor */

    // Constroi o modelo lógico da sala
    private void buildRoom()
    {
        blocos = new Bloco[salaImage.Width, salaImage.Height];
        for (int coluna = 0; coluna < salaImage.Width; coluna++)
        {
            for (int linha = 0; linha < salaImage.Height; linha++)
            {
                blocos[coluna, linha] = pixelToBlock(coluna, linha);
            }
        }
    }

    // Converte um pixel em um bloco
    private Bloco pixelToBlock(int coluna, int linha)
    {
        Color color = salaImage.GetPixel(coluna, linha);

        int index = Game.Colors.IndexOf(Game.Colors.FirstOrDefault(
            c => c.HasValue &&
            c.Value.R == color.R &&
            c.Value.G == color.G &&
            c.Value.B == color.B
            ));

        if (index == -1)
            index = 0;

        return Game.Blocos[index];
    }


    /* Métodos */

    public void CalculateEntitiesMoviment()
    {
        this.entidades.Player.CalculateSelfMoviment(this.blocos, this.entidades);
    }


    /* Métodos renderizadores */


    // Renderiza o background
    public void RenderBackground(Graphics gSala)
    {
        int x = Player.X - 400;
        int y = Player.Y - 300;
        int x2 = (Player.X - 400) / 2;
        int y2 = (Player.Y - 300) / 2;

        if (Player.X < 400)
        {
            x = 0;
            x2 = 0;
        }
        else if (64 * 32 - Player.X < 400)
        {
            x = 64 * 32 - 800;
            x2 = (64 * 32 - 800) / 2;
        }

        if (Player.Y < 300)
        {
            y = 0;
            y2 = 0;
        }
        else if (36 * 32 - Player.Y < 300)
        {
            y = 36 * 32 - 600;
            y2 = (36 * 32 - 600) / 2;
        }

        gSala.Clear(Color.Fuchsia);
        gSala.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        gSala.DrawImage(this.salaBackground, new Rectangle(x, y, 800, 600),
            new Rectangle(x2, y2, 800 / 2, 600 / 2), GraphicsUnit.Pixel);
        //gSala.DrawImage(this.salaBackground, new Rectangle(0, 0, 1080, 600), new Rectangle(0, 0, salaBackground.Width, salaBackground.Height), GraphicsUnit.Pixel);
    }

    // Renderiza a sala
    public void RenderSala(Graphics gSala)
    {
        RenderBackground(gSala);
        RenderBlocos(gSala);
        RenderEntities(gSala);
    }

    // Renderiza os blocos
    private void RenderBlocos(Graphics g)
    {
        for (int linha = 0; linha < this.blocos.GetLength(0); linha++)
        {
            for (int coluna = 0; coluna < this.blocos.GetLength(1); coluna++)
            {
                if (this.blocos[linha, coluna] == null)
                    continue;
                this.blocos[linha, coluna].RenderBloco(linha, coluna, g);
            }
        }
    }

    // Renderiza as entidades
    private void RenderEntities(Graphics g)
    {
        this.entidades.Player.RenderAction(g);
    }
}
