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
    public partial class TelaCadastro : Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
        }

        private async void btConfirmCadastro_Click(object sender, EventArgs e)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            using (var client = new HttpClient(httpClientHandler))
            {
                client.BaseAddress = new Uri("https://absolsmaks.azurewebsites.net/");
                var existe = await client.GetAsync($"User/verifica/{tbLogin.Text}/{tbSenha.Text}");
                if(await existe.Content.ReadAsStringAsync() == "0")
                {
                    var result = await client.PostAsync($"User/register/{tbLogin.Text}/{tbSenha.Text}", null);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                    MessageBox.Show("Cadastro Realizado com sucesso");
                    TelaLogin novo = new TelaLogin();
                    this.Hide();
                    novo.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario ja cadastrado");
                }
            }
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
