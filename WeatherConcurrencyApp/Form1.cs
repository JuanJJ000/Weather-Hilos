using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherConcurrencyApp.Infrastructure.OpenWeatherClient;
using WeatherConcurrentApp.Domain.Entities;

namespace WeatherConcurrencyApp
{
    public partial class FrmMain : Form
    {
        public HttpOpenWeatherClient httpOpenWeatherClient;
        public OpenWeather openWeather;
        private string Intermediario;
        public FrmMain()
        {
            httpOpenWeatherClient = new HttpOpenWeatherClient();
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            a(httpOpenWeatherClient.Extraer());
            try
            {
                Task.Run(Request).Wait();
                if (openWeather == null)
                {
                    throw new NullReferenceException("Fallo al obtener el objeto OpeWeather.");
                }
                WeatherPanel weatherPanel = new WeatherPanel();
                flpContent.Controls.Add(weatherPanel);
            }
            catch (Exception)
            {

                MessageBox.Show("Error de Sistema", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public async Task Request()
        {
            openWeather = await httpOpenWeatherClient.GetWeatherByCityNameAsync("Managua");
        }
        private void flpContent_Paint(object sender, PaintEventArgs e)
        {

        }
        private void a(OpenWeather T)
        {
            Intermediario = T.Sys.City;
            cmbCiudades.Text = Intermediario;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
