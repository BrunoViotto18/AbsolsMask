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
    public void RenderSala()
    {
        this.salaAtual.RenderBackground();
        this.salaAtual.RenderBlocos();
        this.salaAtual.RenderEntities();
    }
}
