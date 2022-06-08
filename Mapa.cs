namespace AbsolsMask;

public class Mapa
{
    // Atributos
    private Sala salaAtual;
    private Sala[,] salas;


    // GET & SET
    public Sala SalaAtual
    {
        get => salaAtual;
        private set => salaAtual = value;
    }


    // Construtor
    public Mapa(Bitmap background)
    {
        this.salaAtual = new Sala(background);
    }


    // Métodos

    // Calcula os movimentos do jogo
    public void CalculateMapMoviments()
    {
        salaAtual.CalculateEntitiesMoviment();
        salaAtual.CalculateEntitiesCollision();
    }

    public void RenderMapaBackground(Graphics gSala)
    {
        this.salaAtual.RenderBackground(gSala);
    }

    // Renderiza o mapa
    public void RenderMapa(Graphics gSala)
    {
        this.salaAtual.RenderSala(gSala);
    }
}
