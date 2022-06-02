namespace AbsolsMask;

public class Sala
{
    private Bitmap salaImage;
    private Bloco[,] blocos;
    private Entidades entidades;

    private TipoSala tipoSala;
    private List<Entradas> entradas;
    private TamanhoSala tamanhoSala;


    // GET & SET
    public int getSalaWidth()
        => blocos.GetLength(0)*32;

    public int getSalaHeight()
        => blocos.GetLength(1)*32;

    public Entidade Player
    {
        get => this.entidades.Player;
    }


    // Construtor
    public Sala()
    {
        this.entidades = new Entidades();
        this.entidades.Player = new Player(10, 10, 150, 150);
        //this.entidades.player = new Player(550, 100);
        this.salaImage = Properties.Salas.Teste;
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

    // Renderiza a sala
    public void RenderSala(Graphics gSala)
    {
        gSala.Clear(Color.Fuchsia);

        RenderBackground(gSala);
        RenderBlocos(gSala);
        RenderEntities(gSala);
    }

    // Renderiza o background
    private void RenderBackground(Graphics g)
    {

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
