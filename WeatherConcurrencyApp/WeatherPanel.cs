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
    public partial class WeatherPanel : UserControl
    {
        public OpenWeather openWeather = new OpenWeather();
        public HttpOpenWeatherClient httpOpenWeatherClient= new HttpOpenWeatherClient();
        public WeatherPanel()
        {
            InitializeComponent();
        }

        private void WeatherPanel_Load(object sender, EventArgs e)
        {

        }

        public void Paneles(OpenWeather openWeather)
        {

           
            lblTemperature.Text = "C° " + openWeather.Main.Temp.ToString();
            lblWeather.Text = openWeather.Weather[0].Main;
            pctbxClima.ImageLocation = "https://api.openweathermap.org/img/w/" + openWeather.Weather[0].Icon + ".png";

            #region detail

            DetailsWeather detailsWeathers0 = new DetailsWeather();
            detailsWeathers0.lblDetail.Text = "Nubosidad";
            detailsWeathers0.lblDetailValue.Text = openWeather.Clouds.All.ToString() + "%";
           flpContent.Controls.Add(detailsWeathers0);

            DetailsWeather detailsWeathers1 = new DetailsWeather();
            detailsWeathers1.lblDetail.Text = "Descripcion";
            detailsWeathers1.lblDetailValue.Text = openWeather.Weather[0].Description;
            flpContent.Controls.Add(detailsWeathers1);

            DetailsWeather detailsWeathers2 = new DetailsWeather();
            detailsWeathers2.lblDetail.Text = "País";
            detailsWeathers2.lblDetailValue.Text = openWeather.Sys.Country;
            flpContent.Controls.Add(detailsWeathers2);

            DetailsWeather detailsWeathers3 = new DetailsWeather();
            detailsWeathers3.lblDetail.Text = "Viento";
            detailsWeathers3.lblDetailValue.Text = openWeather.Wind.Speed.ToString() + " mt/s";
            flpContent.Controls.Add(detailsWeathers3);

            DetailsWeather detailsWeathers4 = new DetailsWeather();
            detailsWeathers4.lblDetail.Text = "Direccion del viento";
            detailsWeathers4.lblDetailValue.Text = openWeather.Wind.Deg.ToString() + "°";
            flpContent.Controls.Add(detailsWeathers4);

            DetailsWeather detailsWeathers5 = new DetailsWeather();
            detailsWeathers5.lblDetail.Text = "Visibilidad";
            detailsWeathers5.lblDetailValue.Text = openWeather.Visibility.ToString() + " mts";
            flpContent.Controls.Add(detailsWeathers5);

            DetailsWeather detailsWeathers6 = new DetailsWeather();
            detailsWeathers6.lblDetail.Text = "Amanecer";
            detailsWeathers6.lblDetailValue.Text = httpOpenWeatherClient.En_tiempo(openWeather.Sys.Sunrise).ToShortTimeString();
            flpContent.Controls.Add(detailsWeathers6);


            DetailsWeather detailsWeathers7 = new DetailsWeather();
            detailsWeathers7.lblDetail.Text = "Atardecer";
            detailsWeathers7.lblDetailValue.Text = httpOpenWeatherClient.En_tiempo(openWeather.Sys.Sunset).ToShortTimeString();
            flpContent.Controls.Add(detailsWeathers7);

            DetailsWeather detailsWeathers8 = new DetailsWeather();
            detailsWeathers8.lblDetail.Text = "Presión";
            detailsWeathers8.lblDetailValue.Text = openWeather.Main.Pressure.ToString() + "/hPa";
            flpContent.Controls.Add(detailsWeathers8);

            DetailsWeather detailsWeathers9 = new DetailsWeather();
            detailsWeathers9.lblDetail.Text = "Humedad";
            detailsWeathers9.lblDetailValue.Text = openWeather.Main.Humidity.ToString() + "%";
            flpContent.Controls.Add(detailsWeathers9);

     
            DetailsWeather detailsWeathers10 = new DetailsWeather();
            detailsWeathers10.lblDetail.Text = "Latitud";
            detailsWeathers10.lblDetailValue.Text = openWeather.Coord.Lat + "°";
            flpContent.Controls.Add(detailsWeathers10);

            DetailsWeather detailsWeathers11 = new DetailsWeather();
            detailsWeathers11.lblDetail.Text = "Longitud";
            detailsWeathers11.lblDetailValue.Text = openWeather.Coord.Lon + "°";
            flpContent.Controls.Add(detailsWeathers11);

          #endregion

        }


    }
}
