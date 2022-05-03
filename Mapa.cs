namespace AbsolsMask;

public class Mapa
{
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
    public void RenderMapa(Graphics gSala, Graphics gCamera)
    {
        this.salaAtual.RenderSala(gSala, gCamera);
    }
}
