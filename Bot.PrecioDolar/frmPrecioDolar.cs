using Bot.PrecioDolar.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot.PrecioDolar
{
    public partial class frmPrecioDolar : Form
    {
        public frmPrecioDolar()
        {
            InitializeComponent();
        }

        private void frmPrecioDolar_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            string tasaAlerta = ConfigurationManager.AppSettings["tasaAlerta"] == null ? "" : ConfigurationManager.AppSettings["tasaAlerta"].ToString();
            int tiempoRefresco = 60;
            int.TryParse(ConfigurationManager.AppSettings["segundosRefresco"].ToString(), out tiempoRefresco);

            txtAlerta.Text = tasaAlerta;
            tmrActualizacion.Interval = tiempoRefresco * 1000;
            ActualizarPrecioDolar();
            tmrActualizacion.Enabled = true;
        }
        private void tmrActualizacion_Tick(object sender, EventArgs e)
        {
            tmrActualizacion.Enabled = false;
            ActualizarPrecioDolar();
            tmrActualizacion.Enabled = true;
        }

        private void ActualizarPrecioDolar()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["tasaAlerta"].Value = txtAlerta.Text;
            config.Save(ConfigurationSaveMode.Modified);

            decimal menorPrecioDolar = 999;
            HttpWebRequest request;
            #region Rextie
            try
            {
                request = (HttpWebRequest)WebRequest.Create("https://app.rextie.com/api/v1/fxrates/rate/?origin=home");

                var postData = "{" +
                                "  \"source_currency\": \"USD\"," +
                                "  \"target_currency\": \"PEN\"," +
                                "  \"source_amount\": 1000" +
                                "}";
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                MontoRecibidoBE recibido = JsonConvert.DeserializeObject<MontoRecibidoBE>(new StreamReader(response.GetResponseStream()).ReadToEnd());

                menorPrecioDolar = decimal.Parse(recibido.fx_rate_sell);
                lblVentaRextie.Text = recibido.fx_rate_sell + " (" + DateTime.Now.ToString("HH:mm:ss") + ")";
            }
            catch (Exception)
            {
            }

            #endregion

            #region Instakash
            try
            {
                request = (HttpWebRequest)WebRequest.Create("https://instakash.net/");
                var response = (HttpWebResponse)request.GetResponse();
                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                int inicioMonto = html.IndexOf("-->", html.IndexOf("Vendemos")) + 3;
                string precioVenta = html.Substring(inicioMonto, html.IndexOf("<", inicioMonto) - inicioMonto);

                if (menorPrecioDolar >= decimal.Parse(precioVenta))
                    menorPrecioDolar = decimal.Parse(precioVenta);
                lblVentaInstaKash.Text = precioVenta + " (" + DateTime.Now.ToString("HH:mm:ss") + ")";
            }
            catch (Exception)
            {
            }
            #endregion

            #region DollarHouse
            try
            {
                request = (HttpWebRequest)WebRequest.Create("https://app.dollarhouse.pe/calculadora");
                var response = (HttpWebResponse)request.GetResponse();
                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                int inicioMonto = html.IndexOf(">", html.IndexOf("Venta:")) + 1;
                string precioVenta = html.Substring(inicioMonto, html.IndexOf("<", inicioMonto) - inicioMonto);

                if (menorPrecioDolar >= decimal.Parse(precioVenta))
                    menorPrecioDolar = decimal.Parse(precioVenta);
                lblVentaDollarHouse.Text = precioVenta + " (" + DateTime.Now.ToString("HH:mm:ss") + ")";
            }
            catch (Exception)
            {
            }
            #endregion

            decimal alerta;
            if (decimal.TryParse(txtAlerta.Text, out alerta))
            {
                if (menorPrecioDolar <= alerta)
                {
                    this.Text = "ALERTA! Dolar a " + menorPrecioDolar.ToString(); ;
                    iconoNotificacion.BalloonTipTitle = "¡Alerta!";
                    iconoNotificacion.BalloonTipText = "El dolar bajó a " + menorPrecioDolar.ToString();
                    iconoNotificacion.ShowBalloonTip(3000);
                }
                else
                {
                    this.Text = "Precio del dólar";
                }
            }
        }

        private void frmPrecioDolar_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }

        private void iconoNotificacion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
    }
}
