namespace AbsolsMask
{
    partial class StartGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_close = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btNewGame = new System.Windows.Forms.Button();
            this.btContinueGame = new System.Windows.Forms.Button();
            this.btOptions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_close
            // 
            this.bt_close.BackColor = System.Drawing.Color.Transparent;
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close.Font = new System.Drawing.Font("Matura MT Script Capitals", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_close.ForeColor = System.Drawing.Color.White;
            this.bt_close.Location = new System.Drawing.Point(12, 625);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(209, 39);
            this.bt_close.TabIndex = 2;
            this.bt_close.Text = "Close";
            this.bt_close.UseVisualStyleBackColor = false;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AbsolsMask.Properties.TelaLogin.TelaFundo;
            this.pictureBox1.Location = new System.Drawing.Point(261, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 678);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btNewGame
            // 
            this.btNewGame.BackColor = System.Drawing.Color.Transparent;
            this.btNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNewGame.Font = new System.Drawing.Font("Matura MT Script Capitals", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btNewGame.ForeColor = System.Drawing.Color.White;
            this.btNewGame.Location = new System.Drawing.Point(12, 127);
            this.btNewGame.Name = "btNewGame";
            this.btNewGame.Size = new System.Drawing.Size(209, 39);
            this.btNewGame.TabIndex = 4;
            this.btNewGame.Text = "New Game";
            this.btNewGame.UseVisualStyleBackColor = false;
            this.btNewGame.Click += new System.EventHandler(this.btNewGame_Click);
            // 
            // btContinueGame
            // 
            this.btContinueGame.BackColor = System.Drawing.Color.Transparent;
            this.btContinueGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btContinueGame.Font = new System.Drawing.Font("Matura MT Script Capitals", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btContinueGame.ForeColor = System.Drawing.Color.White;
            this.btContinueGame.Location = new System.Drawing.Point(12, 192);
            this.btContinueGame.Name = "btContinueGame";
            this.btContinueGame.Size = new System.Drawing.Size(209, 39);
            this.btContinueGame.TabIndex = 5;
            this.btContinueGame.Text = "Continue";
            this.btContinueGame.UseVisualStyleBackColor = false;
            // 
            // btOptions
            // 
            this.btOptions.BackColor = System.Drawing.Color.Transparent;
            this.btOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOptions.Font = new System.Drawing.Font("Matura MT Script Capitals", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btOptions.ForeColor = System.Drawing.Color.White;
            this.btOptions.Location = new System.Drawing.Point(12, 258);
            this.btOptions.Name = "btOptions";
            this.btOptions.Size = new System.Drawing.Size(209, 39);
            this.btOptions.TabIndex = 6;
            this.btOptions.Text = "Options";
            this.btOptions.UseVisualStyleBackColor = false;
            // 
            // StartGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(794, 676);
            this.ControlBox = false;
            this.Controls.Add(this.btOptions);
            this.Controls.Add(this.btContinueGame);
            this.Controls.Add(this.btNewGame);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartGame";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button bt_close;
        private PictureBox pictureBox1;
        private Button btNewGame;
        private Button btContinueGame;
        private Button btOptions;
    }
}