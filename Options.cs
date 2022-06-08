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
    public partial class Options : Form
    {
        public Bitmap bitmap = Properties.Background.Trevisan;

        public Options()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            bitmap = Properties.Background.fundo1;
            this.Close();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            bitmap = Properties.Background.fundo2;
            this.Close();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            bitmap = Properties.Background.Trevisan;
            this.Close();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            bitmap = Properties.Background.fundo3;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
