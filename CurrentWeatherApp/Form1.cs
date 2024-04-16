using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CurrentWeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string city="Ankara";
        string lang = "tr";
        string ApiKey = "84a82b559d7a28fa82e633617adaa1b8";
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text= string.Empty;
            lsbCity.SelectedIndex = 0;comboBox1.SelectedIndex = 0;
            VeriCek(ApiKey, lsbCity.SelectedItem + "", comboBox1.SelectedItem + "");
        }
        private void VeriCek(string Api,string City,string Lang)
        {
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=" + City + "&mode=xml&lang=" + Lang + "&units=metric&appid=" + Api;
            XDocument weather = XDocument.Load(connection);
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var weatherstatus = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
            this.Text = temp + "";
            label1.Text = "Current Weather Status : " + weatherstatus.ToUpper();
        }

        private void lsbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeriCek(ApiKey, lsbCity.SelectedItem + "", comboBox1.SelectedItem + "");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeriCek(ApiKey, lsbCity.SelectedItem + "", comboBox1.SelectedItem + "");
        }
    }
}
