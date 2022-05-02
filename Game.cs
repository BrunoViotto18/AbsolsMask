using System.Windows.Forms;

namespace AbsolsMask;

public class Game : Form
{
    private Random rng;
    private Mapa map;
    private System.Windows.Forms.Timer tm;

    public static List<Color?>? Colors = null;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private PictureBox pictureBox3;
    public static List<Bloco?>? Blocos = null;


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
            this.map.RenderSala();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(553, 336);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(553, 336);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(553, 336);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // Game
            // 
            this.ClientSize = new System.Drawing.Size(553, 336);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

    }
}
