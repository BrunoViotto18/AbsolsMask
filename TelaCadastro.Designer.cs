namespace AbsolsMask
{
    partial class TelaCadastro
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
            this.btConfirmCadastro = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AbsolsMask.Properties.TelaLogin.TelaFundo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(557, 649);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btConfirmCadastro
            // 
            this.btConfirmCadastro.BackColor = System.Drawing.Color.Black;
            this.btConfirmCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirmCadastro.Font = new System.Drawing.Font("Matura MT Script Capitals", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btConfirmCadastro.ForeColor = System.Drawing.Color.White;
            this.btConfirmCadastro.Location = new System.Drawing.Point(150, 405);
            this.btConfirmCadastro.Name = "btConfirmCadastro";
            this.btConfirmCadastro.Size = new System.Drawing.Size(119, 38);
            this.btConfirmCadastro.TabIndex = 3;
            this.btConfirmCadastro.Text = "Confirmar";
            this.btConfirmCadastro.UseVisualStyleBackColor = false;
            this.btConfirmCadastro.Click += new System.EventHandler(this.btConfirmCadastro_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(150, 287);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.PlaceholderText = "Login";
            this.tbLogin.Size = new System.Drawing.Size(257, 23);
            this.tbLogin.TabIndex = 4;
            // 
            // tbSenha
            // 
            this.tbSenha.Location = new System.Drawing.Point(150, 337);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.PlaceholderText = "Senha";
            this.tbSenha.Size = new System.Drawing.Size(257, 23);
            this.tbSenha.TabIndex = 5;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.Black;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Matura MT Script Capitals", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btCancelar.ForeColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(288, 405);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(119, 38);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // TelaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 649);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.btConfirmCadastro);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastro";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button btConfirmCadastro;
        private TextBox tbLogin;
        private TextBox tbSenha;
        private Button btCancelar;
    }
}