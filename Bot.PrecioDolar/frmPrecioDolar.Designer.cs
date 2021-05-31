namespace Bot.PrecioDolar
{
    partial class frmPrecioDolar
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrecioDolar));
            this.label1 = new System.Windows.Forms.Label();
            this.lblVentaRextie = new System.Windows.Forms.Label();
            this.tmrActualizacion = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAlerta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVentaInstaKash = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVentaDollarHouse = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.iconoNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rextie:";
            // 
            // lblVentaRextie
            // 
            this.lblVentaRextie.AutoSize = true;
            this.lblVentaRextie.Location = new System.Drawing.Point(81, 9);
            this.lblVentaRextie.Name = "lblVentaRextie";
            this.lblVentaRextie.Size = new System.Drawing.Size(32, 13);
            this.lblVentaRextie.TabIndex = 1;
            this.lblVentaRextie.Text = "xxxxx";
            // 
            // tmrActualizacion
            // 
            this.tmrActualizacion.Interval = 5000;
            this.tmrActualizacion.Tick += new System.EventHandler(this.tmrActualizacion_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.txtAlerta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(209, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 88);
            this.panel1.TabIndex = 3;
            // 
            // txtAlerta
            // 
            this.txtAlerta.Location = new System.Drawing.Point(4, 38);
            this.txtAlerta.Name = "txtAlerta";
            this.txtAlerta.Size = new System.Drawing.Size(94, 20);
            this.txtAlerta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Notificar si baja a menos de:";
            // 
            // lblVentaInstaKash
            // 
            this.lblVentaInstaKash.AutoSize = true;
            this.lblVentaInstaKash.Location = new System.Drawing.Point(81, 28);
            this.lblVentaInstaKash.Name = "lblVentaInstaKash";
            this.lblVentaInstaKash.Size = new System.Drawing.Size(32, 13);
            this.lblVentaInstaKash.TabIndex = 5;
            this.lblVentaInstaKash.Text = "xxxxx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "InstaKash:";
            // 
            // lblVentaDollarHouse
            // 
            this.lblVentaDollarHouse.AutoSize = true;
            this.lblVentaDollarHouse.Location = new System.Drawing.Point(81, 47);
            this.lblVentaDollarHouse.Name = "lblVentaDollarHouse";
            this.lblVentaDollarHouse.Size = new System.Drawing.Size(32, 13);
            this.lblVentaDollarHouse.TabIndex = 7;
            this.lblVentaDollarHouse.Text = "xxxxx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "DollarHouse:";
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.iconoNotificacion.Icon = ((System.Drawing.Icon)(resources.GetObject("iconoNotificacion.Icon")));
            this.iconoNotificacion.Text = "Precio del dolar";
            this.iconoNotificacion.Visible = true;
            this.iconoNotificacion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.iconoNotificacion_MouseDoubleClick);
            // 
            // frmPrecioDolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 88);
            this.Controls.Add(this.lblVentaDollarHouse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblVentaInstaKash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblVentaRextie);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrecioDolar";
            this.Text = "Precio del dólar";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmPrecioDolar_Load);
            this.Resize += new System.EventHandler(this.frmPrecioDolar_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVentaRextie;
        private System.Windows.Forms.Timer tmrActualizacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAlerta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVentaInstaKash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVentaDollarHouse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NotifyIcon iconoNotificacion;
    }
}

