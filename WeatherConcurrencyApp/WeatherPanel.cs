using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherConcurrencyApp
{
    public partial class WeatherPanel : UserControl
    {
        public WeatherPanel()
        {
            InitializeComponent();
        }

        private void WeatherPanel_Load(object sender, EventArgs e)
        {
            DetailsWeather detailsWeather = new DetailsWeather();
            flpContent.Controls.Add(detailsWeather);
        }
    }
}
