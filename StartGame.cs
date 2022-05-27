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
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            TelaLogin novo = new TelaLogin();
            this.Hide();
            novo.ShowDialog();
            this.Close();
        }

        private void btNewGame_Click(object sender, EventArgs e)
        {
            Game novo = new Game(12345);
            this.Hide();
            novo.ShowDialog();
            this.Close();
        }
    }
}
