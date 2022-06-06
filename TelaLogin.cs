using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace AbsolsMask
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btLogin_Click(object sender, EventArgs e)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            using (var client = new HttpClient(httpClientHandler))
            {
                client.BaseAddress = new Uri("https://absolsmaks.azurewebsites.net/");
                var existe = await client.GetAsync($"User/login/{tbLogin.Text}/{tbSenha.Text}");
                if (await existe.Content.ReadAsStringAsync() != "0")
                {
                    var result = await client.PostAsync($"User/login/{tbLogin.Text}/{tbSenha.Text}", null);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    StartGame novo = new StartGame(resultContent);
                    this.Hide();
                    novo.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario não cadastrado");
                }
            }
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            TelaCadastro novo = new TelaCadastro();
            this.Hide();
            novo.ShowDialog();
            this.Close();
        }
    }
}
