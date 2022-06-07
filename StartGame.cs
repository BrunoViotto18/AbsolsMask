using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbsolsMask
{
    public partial class StartGame : Form
    {
        string texto;
        public StartGame(string text)
        {
            InitializeComponent();
            texto = text;
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            TelaLogin novo = new TelaLogin();
            this.Hide();
            novo.ShowDialog();
            this.Close();
        }

        private async void btNewGame_Click(object sender, EventArgs e)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            using (var client = new HttpClient(httpClientHandler))
            {
                /*
                client.BaseAddress = new Uri("http://localhost:5141/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new
                {
                    id = 1,
                    login = "bruno",
                    password = 0258520
                };
                MessageBox.Show(user.ToString());
                var novo = new
                {
                    user = user,
                    date = "0001-01-01",
                    seed = 12345,
                    sala_X = 1,
                    sala_Y = 1,
                    porta = 1
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(
        "Game/register", novo);

                response.EnsureSuccessStatusCode();
                
                MessageBox.Show(texto);
                */
                Game game = new(12345);
                this.Hide();
                game.ShowDialog();
                this.Close();
            }
        }

        private void btOptions_Click(object sender, EventArgs e)
        {

        }
    }
}
