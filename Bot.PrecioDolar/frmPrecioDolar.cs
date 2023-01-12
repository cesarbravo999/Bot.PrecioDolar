using Bot.PrecioDolar.Clases;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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

        private const int BrowserEmulationValueEdge14 = 0x00002EE1; // Microsoft Edge
        private const int BrowserEmulationValueIE11 = 0x00002AF9; // IE11
        private const int BrowserEmulationValueIE10 = 0x00002711; // IE10
        private const int BrowserEmulationValueIE9 = 0x0000270F; // IE9

        private const string BrowserEmulationSubKey = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
        private const int BrowserEmulationValue = BrowserEmulationValueIE11;

        DateTime? fechaNoActualizacion;

        private static string GetApplicationName()
        {
            return $"{Process.GetCurrentProcess().ProcessName}.exe";
        }

        public static void ChangeInternetExplorerVersion()
        {
            RegistryKey registrybrowser = Registry.CurrentUser.OpenSubKey(BrowserEmulationSubKey, true);

            if (registrybrowser == null)
            {
                registrybrowser = Registry.CurrentUser.CreateSubKey(BrowserEmulationSubKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            string applicationName = GetApplicationName();
            object currentValue = registrybrowser?.GetValue(applicationName);

            if (currentValue == null || (int)currentValue != BrowserEmulationValue)
            {
                registrybrowser?.SetValue(applicationName, BrowserEmulationValue, RegistryValueKind.DWord);
            }
            registrybrowser?.Close();
        }

        private void frmPrecioDolar_Load(object sender, EventArgs e)
        {
            ChangeInternetExplorerVersion();

            string tasaAlerta = ConfigurationManager.AppSettings["tasaAlerta"] == null ? "" : ConfigurationManager.AppSettings["tasaAlerta"].ToString();
            int tiempoRefresco = 60;
            int.TryParse(ConfigurationManager.AppSettings["segundosRefresco"].ToString(), out tiempoRefresco);

            txtAlerta.Text = tasaAlerta;
            tmrActualizacion.Interval = tiempoRefresco * 1000;
            ActualizarPrecioDolar();
            tmrActualizacion.Enabled = true;
        }

        WebBrowser web;
        public void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                string textoRecibido = web.Document.Body.InnerHtml;

                if (textoRecibido.Contains("robot"))
                {
                    if (chkAuto.Checked == true)
                    {
                        this.Height = 134;
                        fechaNoActualizacion = DateTime.Now.AddMinutes(5);
                    }
                    else
                    {
                        panel4.Controls.Clear();
                        panel4.Controls.Add(web);
                        this.Height = 627;
                    }
                    web.Dispose();
                    web = null;
                }
                else
                {
                    List<DatosBloombergBE> recibido = JsonConvert.DeserializeObject<List<DatosBloombergBE>>(textoRecibido.Replace("<pre>", "")
                                                                                                                          .Replace("</pre>", ""));
                    this.Height = 134;

                    DatosBloombergBE datoReal = recibido.FirstOrDefault();

                    if (lblPrecioBloomberg.InvokeRequired)
                    {
                        lblPrecioBloomberg.BeginInvoke((MethodInvoker)delegate () { lblPrecioBloomberg.Text = datoReal.price.ToString("0.00000") + " (" + datoReal.percentChange1Day.ToString("0.00") + "%)"; });
                        lblAperturaBloomberg.BeginInvoke((MethodInvoker)delegate () { lblAperturaBloomberg.Text = datoReal.openPrice.ToString("0.00000"); });
                        lblCierreAyerBloomberg.BeginInvoke((MethodInvoker)delegate () { lblCierreAyerBloomberg.Text = datoReal.previousClosingPriceOneTradingDayAgo.ToString("0.00000"); });
                        lblFechaBloomberg.BeginInvoke((MethodInvoker)delegate () { lblFechaBloomberg.Text = "Actualizado a las " + DateTime.Now.ToString("HH:mm:ss") + ""; });
                    }
                    else
                    {
                        lblPrecioBloomberg.Text = datoReal.price.ToString("0.00000") + " (" + datoReal.percentChange1Day.ToString("0.00") + "%)";
                        lblAperturaBloomberg.Text = datoReal.openPrice.ToString("0.00000");
                        lblCierreAyerBloomberg.Text = datoReal.previousClosingPriceOneTradingDayAgo.ToString("0.00000");
                        lblFechaBloomberg.Text = "Actualizado a las " + DateTime.Now.ToString("HH:mm:ss");
                    }
                    web.Dispose();
                    web = null;
                }
            }
            catch (Exception ex)
            {
                if (lblPrecioBloomberg.InvokeRequired)
                {
                    lblPrecioBloomberg.BeginInvoke((MethodInvoker)delegate () { lblPrecioBloomberg.Text = "Resolver captcha"; });
                    lblAperturaBloomberg.BeginInvoke((MethodInvoker)delegate () { lblAperturaBloomberg.Text = "??"; });
                    lblCierreAyerBloomberg.BeginInvoke((MethodInvoker)delegate () { lblCierreAyerBloomberg.Text = "??"; });
                    lblFechaBloomberg.BeginInvoke((MethodInvoker)delegate () { lblFechaBloomberg.Text = "Actualizado a las " + DateTime.Now.ToString("HH:mm:ss"); });
                }
                else
                {
                    lblPrecioBloomberg.Text = "Resolver captcha";
                    lblAperturaBloomberg.Text = "??";
                    lblCierreAyerBloomberg.Text = "??";
                }
            }
            
        }


        private void tmrActualizacion_Tick(object sender, EventArgs e)
        {
            tmrActualizacion.Enabled = false;
            ActualizarPrecioDolar();
            tmrActualizacion.Enabled = true;
        }

        CookieContainer cookieInvocacion = new CookieContainer();
        Thread hiloRextie,
               hiloInstaKash,
               hiloDollarHouse,
               hiloTKambio;

        private void ActualizarPrecioDolar()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["tasaAlerta"].Value = txtAlerta.Text;
            config.Save(ConfigurationSaveMode.Modified);

            decimal alerta;
            if (decimal.TryParse(txtAlerta.Text, out alerta))
            {
                decimal menorPrecioDolar = decimal.MaxValue,
                        dummyValor;

                if (decimal.TryParse(lblVentaRextie.Text.Split('(')[0].Trim(), out dummyValor))
                {
                    menorPrecioDolar = dummyValor;
                }
                /*if (decimal.TryParse(lblVentaInstaKash.Text.Split('(')[0].Trim(), out dummyValor))
                {
                    if (dummyValor < menorPrecioDolar)
                    {
                        menorPrecioDolar = dummyValor;
                    }
                }
                if (decimal.TryParse(lblVentaDollarHouse.Text.Split('(')[0].Trim(), out dummyValor))
                {
                    if (dummyValor < menorPrecioDolar)
                    {
                        menorPrecioDolar = dummyValor;
                    }
                }*/


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

            #region Rextie
            hiloRextie = new Thread(new ThreadStart(() =>
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://app.rextie.com/api/v1/fxrates/rate/?origin=home");

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

                    DatosRextieBE recibido = JsonConvert.DeserializeObject<DatosRextieBE>(new StreamReader(response.GetResponseStream()).ReadToEnd());

                    if (recibido.fx_rate_sell != null && decimal.Parse(recibido.fx_rate_sell) > 0)
                        if (lblVentaRextie.InvokeRequired)
                        {
                            lblVentaRextie.BeginInvoke((MethodInvoker)delegate () { lblVentaRextie.Text = decimal.Parse(recibido.fx_rate_sell).ToString("0.00000") + " (" + DateTime.Now.ToString("HH:mm:ss") + ")"; });
                        }
                        else
                        {
                            lblVentaRextie.Text = decimal.Parse(recibido.fx_rate_sell).ToString("0.00000") + " (" + DateTime.Now.ToString("HH:mm:ss") + ")";
                        }
                }
                catch (Exception ex)
                {
                }
            }));
            hiloRextie.Start();
            #endregion

            #region Instakash
            hiloInstaKash = new Thread(new ThreadStart(() =>
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.instakash.net/exchange-service/api/v1/client/rates");
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                    var response = (HttpWebResponse)request.GetResponse();

                    List<DatosInstaKashBE> recibido = JsonConvert.DeserializeObject<List<DatosInstaKashBE>>(new StreamReader(response.GetResponseStream()).ReadToEnd());

                    if (recibido.FirstOrDefault() != null && decimal.Parse(recibido.First().sell) > 0)
                        if (lblVentaInstaKash.InvokeRequired)
                        {
                            lblVentaInstaKash.BeginInvoke((MethodInvoker)delegate () { lblVentaInstaKash.Text = decimal.Parse(recibido.First().sell).ToString("0.00000") + " (" + DateTime.Now.ToString("HH:mm:ss") + ")"; });
                        }
                        else
                        {
                            lblVentaInstaKash.Text = decimal.Parse(recibido.First().sell).ToString("0.00000") + " (" + DateTime.Now.ToString("HH:mm:ss") + ")";
                        }
                }
                catch (Exception ex)
                {
                }
            }));
            hiloInstaKash.Start();
            #endregion

            #region DollarHouse
            hiloDollarHouse = new Thread(new ThreadStart(() =>
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://app.dollarhouse.pe/calculadora");
                    var response = (HttpWebResponse)request.GetResponse();
                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    int inicioMonto = html.IndexOf(">", html.IndexOf("Venta:")) + 1;
                    string precioVenta = html.Substring(inicioMonto, html.IndexOf("<", inicioMonto) - inicioMonto);

                    if (decimal.Parse(precioVenta) > 0)
                        if (lblVentaDollarHouse.InvokeRequired)
                        {
                            lblVentaDollarHouse.BeginInvoke((MethodInvoker)delegate () { lblVentaDollarHouse.Text = decimal.Parse(precioVenta).ToString("0.00000") + " (" + DateTime.Now.ToString("HH:mm:ss") + ")"; });
                        }
                        else
                        {
                            lblVentaDollarHouse.Text = decimal.Parse(precioVenta).ToString("0.00000") + " (" + DateTime.Now.ToString("HH:mm:ss") + ")";
                        }
                }
                catch (Exception)
                {
                }
            }));
            hiloDollarHouse.Start();
            #endregion

            #region TKambio
            hiloTKambio = new Thread(new ThreadStart(() =>
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tkambio.com/wp-admin/admin-ajax.php?action=get_exchange_rate");
                    var response = (HttpWebResponse)request.GetResponse();

                    DatosTKambioBE recibido = JsonConvert.DeserializeObject<DatosTKambioBE>(new StreamReader(response.GetResponseStream()).ReadToEnd());

                    if (recibido.selling_rate != null && decimal.Parse(recibido.selling_rate) > 0)
                        if (lblVentaTKambio.InvokeRequired)
                        {
                            lblVentaTKambio.BeginInvoke((MethodInvoker)delegate () { lblVentaTKambio.Text = decimal.Parse(recibido.selling_rate).ToString("0.00000") + " (" + DateTime.Now.ToString("HH:mm:ss") + ")"; });
                        }
                        else
                        {
                            lblVentaTKambio.Text = decimal.Parse(recibido.selling_rate).ToString("0.00000") + " (" + DateTime.Now.ToString("HH:mm:ss") + ")";
                        }
                }
                catch (Exception ex)
                {
                }
            }));
            hiloTKambio.Start();
            #endregion

            if (this.Height == 134 && (fechaNoActualizacion == null || fechaNoActualizacion.Value < DateTime.Now))
            {
                fechaNoActualizacion = null;
                web = new WebBrowser();
                web.ScriptErrorsSuppressed = true;
                web.DocumentCompleted += WebBrowser_DocumentCompleted;
                web.Dock = DockStyle.Fill;
                web.Navigate("https://www.bloomberg.com/markets2/api/datastrip/PEN%3ACUR%2CUSD%3ACUR%2CINDU%3AIND?locale=en&customTickerList=true");
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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            web.Navigate("https://www.bloomberg.com/markets2/api/datastrip/PEN%3ACUR%2CUSD%3ACUR%2CINDU%3AIND?locale=en&customTickerList=true");
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            fechaNoActualizacion = DateTime.Now.AddMinutes(5);
            this.Height = 134;
        }
    }
}
