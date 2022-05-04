﻿namespace AbsolsMask;

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
        get => this.entidades.player;
    }


    // Construtor
    public Sala()
    {
        this.entidades = new Entidades();
        this.entidades.player = new Player(10, 10, 130, 130, 10);
        //this.entidades.player = new Player(550, 100);
        this.salaImage = new Bitmap("Sprites/Salas/debug1.png");
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
        int index = Game.Colors.IndexOf(this.salaImage.GetPixel(coluna, linha));
        if (index == -1)
            index = 0;
        return Game.Blocos[index];
    }


    /* Métodos */

    public void CalculateEntityMoviment()
    {

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
        this.entidades.player.RenderSelf(g);
    }
}
