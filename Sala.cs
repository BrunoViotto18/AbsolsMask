namespace AbsolsMask;

public class Sala
{
    private Bitmap salaImage;
    private Bloco[,] blocos;
    private Entidades entidades;

    private TipoSala tipoSala;
    private List<Entradas> entradas;
    private TamanhoSala tamanhoSala;


    // Construtor
    public Sala()
    {
        this.salaImage = new Bitmap(Directory.GetCurrentDirectory() + "/sprites/salas/salaDebug1.png");
        buildRoom();
    }

    //Métodos

    // Constroi o modelo lógico da sala
    private void buildRoom()
    {
        blocos = new Bloco[salaImage.Width, salaImage.Height];
        for (int linha = 0; linha < salaImage.Height; linha++)
        {
            for (int coluna = 0; coluna < salaImage.Width; coluna++)
            {
                blocos[linha, coluna] = pixelToBlock(linha, coluna);
            }
        }
    }

    // Converte um pixel em um bloco
    private Bloco pixelToBlock(int linha, int coluna)
    {
        int index = Game.Colors.IndexOf(this.salaImage.GetPixel(coluna, linha));
        if (index == -1)
            index = 0;
        return Game.Blocos[index];
    }

    public void CalculateEntityMoviment()
    {

    }

    // Renderiza a sala
    public void RenderSala(Graphics background, Graphics blocos, Graphics entidades)
    {
        RenderBackground(background);
        RenderBlocos(blocos);
        RenderEntities(entidades);
    }

    private void RenderBackground(Graphics background)
    {

    }

    private void RenderBlocos(Graphics blocos)
    {
        foreach (Bloco bloco in this.blocos)
        {
            bloco.RenderBloco(blocos);
        }
    }

    private void RenderEntities(Graphics entidades)
    {

    }
}
