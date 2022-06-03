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
    public Mapa()
    {
        this.salaAtual = new Sala();
    }


    // Métodos

    // Calcula os movimentos do jogo
    public void CalculateMapMoviments()
    {
        this.salaAtual.CalculateEntitiesMoviment();
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
