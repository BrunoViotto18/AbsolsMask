namespace AbsolsMask;

public class Mapa
{
    private Sala salaAtual;
    private Sala[,] salas;

    // Construtor
    public Mapa()
    {
        this.salaAtual = new Sala();
    }

    // Métodos
    public void RenderMapa(Graphics background, Graphics blocos, Graphics entidades)
    {
        this.salaAtual.RenderSala(background, blocos, entidades);
    }
}
