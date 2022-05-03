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
using Newtonsoft.Json;

namespace WeatherConcurrencyApp
{
    public partial class FrmMain : Form
    {
        public HttpOpenWeatherClient httpOpenWeatherClient;
        public OpenWeather openWeather;
        string city= string.Empty;
        public FrmMain()
        {
            httpOpenWeatherClient = new HttpOpenWeatherClient();
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            a(httpOpenWeatherClient.GetCityNames());
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
         city = cmbCiudades.Text;

            if (cmbCiudades.Text == string.Empty || cmbCiudades == null)
            {
                MessageBox.Show("Por favor escoga una ciudad");
                return;

            }


            try
            {
                Task.Run(Request).Wait();
                if (openWeather == null)
                {
                    throw new NullReferenceException("Fallo al obtener el objeto OpeWeather.");
                }
                Nulls();
                 if(openWeather.Name == null)
                {
                    MessageBox.Show("No se encontro la ciudad o no es válida");
                }


               
            }
            catch (Exception)
            {

                MessageBox.Show("Error de Sistema", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public async Task Request()
        {

            openWeather = await httpOpenWeatherClient.GetWeatherByCityNameAsync(city);
        
        }
       
        private void a(List<OpenWeather> T)
        {
            T = httpOpenWeatherClient.GetCityNames();
           
            for(int i =0; i< T.Count;i++)
            {
                cmbCiudades.Items.Add(T[i].Name);
            }
            
            
        }

        private void Nulls()
        {

            WeatherPanel weatherPanel = new WeatherPanel();
            weatherPanel.lblCity.Text = city;
            weatherPanel.lblTemperature.Text = "C° "+openWeather.Main.Temp.ToString();
            weatherPanel.lblWeather.Text = openWeather.Weather[0].Main;
            flpContent.Controls.Add(weatherPanel);
           


        }

    }
}
