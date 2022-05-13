using System.Windows.Forms;

namespace AbsolsMask;

public class Game : Form
{
    private System.Windows.Forms.Timer tm;
    private Random rng;
    private Mapa map;
    private int seed;

    private Bitmap bmpSala;
    private Bitmap bmpCamera;
    private Graphics gSala;
    private Graphics gCamera;

    public static List<Color?>? Colors = null;
    public static List<Bloco?>? Blocos = null;

    private PictureBox pbTela;


    // GET & SET
    public Random RNG
    {
        get => rng;
        private set => rng = value;
    }


    // Construtor
    public Game(int seed)
    {
        this.seed = seed;

        InitializeComponent();
    }

    // Inicializa o array de coress para blocos
    private void setColorBlocks()
    {
        if (Game.Colors != null)
            return;

        Game.Colors = new List<Color?>();
        Game.Blocos = new List<Bloco?>();

        // NULL
        Colors.Add(null);
        Blocos.Add(null);

        // DEBUG
        Colors.Add(Color.FromArgb(170, 0, 255));
        Blocos.Add(new Debug());
    }


    private void InitializeComponent()
    {
            this.pbTela = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTela)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTela
            // 
            this.pbTela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbTela.Location = new System.Drawing.Point(0, 0);
            this.pbTela.Name = "pbTela";
            this.pbTela.Size = new System.Drawing.Size(784, 561);
            this.pbTela.TabIndex = 0;
            this.pbTela.TabStop = false;
            // 
            // Game
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pbTela);
            this.MaximizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTela)).EndInit();
            this.ResumeLayout(false);

    }


    private void CalculateGameMoviments()
    {
        this.map.CalculateMapMoviments();
    }


    /* Métodos de Renderização */

    // Renderiza o jogo (Sala)
    private void RenderGame(Graphics gSala)
    {
        this.map.RenderMapa(gSala);
    }

    // Renderiza a camera do jogo
    private void RenderCamera(Bitmap bmpSala, Graphics gCamera)
    {
        gCamera.Clear(Color.Fuchsia);

        int cameraTop = this.map.SalaAtual.Player.Y - pbTela.Height / 2;
        int cameraLeft = this.map.SalaAtual.Player.X - pbTela.Width / 2;
        
        if (cameraTop < 0)
            cameraTop = 0;
        else if (cameraTop + pbTela.Height > this.map.SalaAtual.getSalaHeight())
            cameraTop = this.map.SalaAtual.getSalaHeight() - pbTela.Height;

        if (cameraLeft < 0)
            cameraLeft = 0;
        else if (cameraLeft + pbTela.Width > this.map.SalaAtual.getSalaWidth())
            cameraLeft = this.map.SalaAtual.getSalaWidth() - pbTela.Width;

        gCamera.DrawImage(bmpSala, new Rectangle(0, 0, pbTela.Width, pbTela.Height), new Rectangle(cameraLeft, cameraTop, pbTela.Width, pbTela.Height), GraphicsUnit.Pixel);
    }



    private void Game_Load(object sender, EventArgs e)
    {
        setColorBlocks();


        // Random e Timer
        rng = new Random(this.seed);
        this.tm = new System.Windows.Forms.Timer();
        this.tm.Interval = 16;
        //this.tm.Interval = 200;


        // Criação de objetos
        this.map = new Mapa();


        // Criação dos objetos gráficos
        bmpSala = new Bitmap(this.map.SalaAtual.getSalaWidth(), this.map.SalaAtual.getSalaHeight());
        bmpCamera = new Bitmap(pbTela.Width, pbTela.Height);

        gCamera = Graphics.FromImage(bmpCamera);
        gSala = Graphics.FromImage(bmpSala);

        this.KeyPreview = true;
        this.KeyDown += (s, e) =>
        {
            KeyPressManager.AddKey(e.KeyCode);
        };

        this.KeyUp += (s, e) =>
        {
            KeyPressManager.RemoveKey(e.KeyCode);
        };

        // Delegação do tick
        this.tm.Tick += delegate
        {
            // Calculando movimentos(Eventos?)
            CalculateGameMoviments();

            // Renderizando o jogo
            RenderGame(gSala);
            RenderCamera(bmpSala, gCamera);
            pbTela.Image = bmpCamera;
        };


        this.tm.Start();
    }
}
