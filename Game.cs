using System.Windows.Forms;

namespace AbsolsMask;

public class Game : Form
{
    private Random rng;
    private Mapa map;
    private System.Windows.Forms.Timer tm;
    private Graphics gBackground;
    private Graphics gBlocos;
    private Graphics gEntidades;

    public static List<Color?>? Colors = null;
    public static List<Bloco?>? Blocos = null;

    // PictureBoxes
    private PictureBox pbBackground;
    private PictureBox pbBlocos;
    private PictureBox pbEntidades;


    // GET & SET
    public Random RNG
    {
        get => rng;
        private set => rng = value;
    }

    // Construtor
    public Game(int seed)
    {
        setColorBlocks();

        // Random e Timer
        rng = new Random(seed);
        this.tm = new System.Windows.Forms.Timer();
        this.tm.Interval = 1 / 60;


        // Criação de objetos
        this.map = new Mapa();


        // Delegação do tick
        this.tm.Tick += delegate
        {
            Bitmap bmpBackground = new Bitmap(pbBackground.Width, pbBackground.Height);
            Bitmap bmpBlocos = new Bitmap(pbBlocos.Width, pbBlocos.Height);
            Bitmap bmpEntidades = new Bitmap(pbEntidades.Width, pbEntidades.Height);

            gBackground = Graphics.FromImage(bmpBackground);
            gBlocos = Graphics.FromImage(bmpBlocos);
            gEntidades = Graphics.FromImage(bmpEntidades);

            this.map.RenderMapa(gBackground, gBlocos, gEntidades);
        };

        this.tm.Start();
    }

    private void setColorBlocks()
    {
        if (Colors != null)
            return;

        Colors.Add(null);
        Blocos.Add(null);

        // Debug
        Colors.Add(Color.FromArgb(170, 0, 255));
        Blocos.Add(new Debug());
    }

    private void InitializeComponent()
    {
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.pbBlocos = new System.Windows.Forms.PictureBox();
            this.pbEntidades = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlocos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEntidades)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackground
            // 
            this.pbBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackground.Location = new System.Drawing.Point(0, 0);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(553, 336);
            this.pbBackground.TabIndex = 0;
            this.pbBackground.TabStop = false;
            // 
            // pbBlocos
            // 
            this.pbBlocos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBlocos.Location = new System.Drawing.Point(0, 0);
            this.pbBlocos.Name = "pbBlocos";
            this.pbBlocos.Size = new System.Drawing.Size(553, 336);
            this.pbBlocos.TabIndex = 1;
            this.pbBlocos.TabStop = false;
            // 
            // pbEntidades
            // 
            this.pbEntidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEntidades.Location = new System.Drawing.Point(0, 0);
            this.pbEntidades.Name = "pbEntidades";
            this.pbEntidades.Size = new System.Drawing.Size(553, 336);
            this.pbEntidades.TabIndex = 2;
            this.pbEntidades.TabStop = false;
            // 
            // Game
            // 
            this.ClientSize = new System.Drawing.Size(553, 336);
            this.Controls.Add(this.pbEntidades);
            this.Controls.Add(this.pbBlocos);
            this.Controls.Add(this.pbBackground);
            this.Name = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlocos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEntidades)).EndInit();
            this.ResumeLayout(false);

    }
}
