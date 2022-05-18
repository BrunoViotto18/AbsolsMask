namespace AbsolsMask
{
    partial class TelaLogin
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bt_close = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.btRegister = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AbsolsMask.Properties.TelaLogin.TelaFundo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(573, 688);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bt_close
            // 
            this.bt_close.BackColor = System.Drawing.Color.Transparent;
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close.Font = new System.Drawing.Font("Matura MT Script Capitals", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_close.ForeColor = System.Drawing.Color.White;
            this.bt_close.Location = new System.Drawing.Point(159, 590);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(257, 39);
            this.bt_close.TabIndex = 1;
            this.bt_close.Text = "Close";
            this.bt_close.UseVisualStyleBackColor = false;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.Black;
            this.btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogin.Font = new System.Drawing.Font("Matura MT Script Capitals", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btLogin.ForeColor = System.Drawing.Color.White;
            this.btLogin.Location = new System.Drawing.Point(159, 531);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(106, 38);
            this.btLogin.TabIndex = 2;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(159, 379);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.PlaceholderText = "Login";
            this.tbLogin.Size = new System.Drawing.Size(257, 23);
            this.tbLogin.TabIndex = 3;
            // 
            // tbSenha
            // 
            this.tbSenha.Location = new System.Drawing.Point(159, 442);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.PlaceholderText = "Senha";
            this.tbSenha.Size = new System.Drawing.Size(257, 23);
            this.tbSenha.TabIndex = 4;
            // 
            // btRegister
            // 
            this.btRegister.BackColor = System.Drawing.Color.Black;
            this.btRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRegister.Font = new System.Drawing.Font("Matura MT Script Capitals", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btRegister.ForeColor = System.Drawing.Color.White;
            this.btRegister.Location = new System.Drawing.Point(310, 531);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(106, 38);
            this.btRegister.TabIndex = 5;
            this.btRegister.Text = "Register";
            this.btRegister.UseVisualStyleBackColor = false;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // TelaLogin
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(573, 688);
            this.ControlBox = false;
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaLogin";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button bt_close;
        private Button btLogin;
        private Label lbLogin;
        private Label label3;
        private TextBox tbLogin;
        private TextBox tbSenha;
        private Button btRegister;
    }
}