using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbsolsMask
{
    public partial class TelaCadastro : Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
        }

        private void btConfirmCadastro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cadastro Realizado com sucesso");
            TelaLogin novo = new TelaLogin();
            this.Hide();
            novo.ShowDialog();
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            TelaLogin novo = new TelaLogin();
            this.Hide();
            novo.ShowDialog();
            this.Close();
        }
    }
}
