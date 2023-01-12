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
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrecioBloomberg = new System.Windows.Forms.Label();
            this.lblCierreAyerBloomberg = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAperturaBloomberg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFechaBloomberg = new System.Windows.Forms.Label();
            this.pnlWeb = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.lblVentaTKambio = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlWeb.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rextie:";
            // 
            // lblVentaRextie
            // 
            this.lblVentaRextie.AutoSize = true;
            this.lblVentaRextie.Location = new System.Drawing.Point(262, 11);
            this.lblVentaRextie.Name = "lblVentaRextie";
            this.lblVentaRextie.Size = new System.Drawing.Size(0, 13);
            this.lblVentaRextie.TabIndex = 1;
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
            this.panel1.Location = new System.Drawing.Point(383, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 96);
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
            this.lblVentaInstaKash.Location = new System.Drawing.Point(262, 30);
            this.lblVentaInstaKash.Name = "lblVentaInstaKash";
            this.lblVentaInstaKash.Size = new System.Drawing.Size(0, 13);
            this.lblVentaInstaKash.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(185, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "InstaKash:";
            // 
            // lblVentaDollarHouse
            // 
            this.lblVentaDollarHouse.AutoSize = true;
            this.lblVentaDollarHouse.Location = new System.Drawing.Point(262, 49);
            this.lblVentaDollarHouse.Name = "lblVentaDollarHouse";
            this.lblVentaDollarHouse.Size = new System.Drawing.Size(0, 13);
            this.lblVentaDollarHouse.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(185, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bloomberg:";
            // 
            // lblPrecioBloomberg
            // 
            this.lblPrecioBloomberg.AutoSize = true;
            this.lblPrecioBloomberg.Location = new System.Drawing.Point(78, 10);
            this.lblPrecioBloomberg.Name = "lblPrecioBloomberg";
            this.lblPrecioBloomberg.Size = new System.Drawing.Size(0, 13);
            this.lblPrecioBloomberg.TabIndex = 9;
            // 
            // lblCierreAyerBloomberg
            // 
            this.lblCierreAyerBloomberg.Location = new System.Drawing.Point(12, 48);
            this.lblCierreAyerBloomberg.Name = "lblCierreAyerBloomberg";
            this.lblCierreAyerBloomberg.Size = new System.Drawing.Size(70, 13);
            this.lblCierreAyerBloomberg.TabIndex = 10;
            this.lblCierreAyerBloomberg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cierre ayer:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(91, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Apertura:";
            // 
            // lblAperturaBloomberg
            // 
            this.lblAperturaBloomberg.Location = new System.Drawing.Point(91, 48);
            this.lblAperturaBloomberg.Name = "lblAperturaBloomberg";
            this.lblAperturaBloomberg.Size = new System.Drawing.Size(59, 13);
            this.lblAperturaBloomberg.TabIndex = 12;
            this.lblAperturaBloomberg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Location = new System.Drawing.Point(175, -4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 100);
            this.panel2.TabIndex = 14;
            // 
            // lblFechaBloomberg
            // 
            this.lblFechaBloomberg.AutoSize = true;
            this.lblFechaBloomberg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaBloomberg.Location = new System.Drawing.Point(1, 73);
            this.lblFechaBloomberg.Name = "lblFechaBloomberg";
            this.lblFechaBloomberg.Size = new System.Drawing.Size(0, 12);
            this.lblFechaBloomberg.TabIndex = 15;
            this.lblFechaBloomberg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlWeb
            // 
            this.pnlWeb.Controls.Add(this.panel4);
            this.pnlWeb.Controls.Add(this.panel3);
            this.pnlWeb.Location = new System.Drawing.Point(0, 96);
            this.pnlWeb.Name = "pnlWeb";
            this.pnlWeb.Size = new System.Drawing.Size(486, 492);
            this.pnlWeb.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(486, 468);
            this.panel4.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRefrescar);
            this.panel3.Controls.Add(this.btnCerrar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(486, 24);
            this.panel3.TabIndex = 2;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefrescar.Location = new System.Drawing.Point(0, 0);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(455, 24);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.Location = new System.Drawing.Point(455, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(31, 24);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(127, 75);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(48, 17);
            this.chkAuto.TabIndex = 17;
            this.chkAuto.Text = "Auto";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // lblVentaTKambio
            // 
            this.lblVentaTKambio.AutoSize = true;
            this.lblVentaTKambio.Location = new System.Drawing.Point(262, 68);
            this.lblVentaTKambio.Name = "lblVentaTKambio";
            this.lblVentaTKambio.Size = new System.Drawing.Size(0, 13);
            this.lblVentaTKambio.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(185, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "TKambio:";
            // 
            // frmPrecioDolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 95);
            this.Controls.Add(this.lblVentaTKambio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.pnlWeb);
            this.Controls.Add(this.lblFechaBloomberg);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblAperturaBloomberg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCierreAyerBloomberg);
            this.Controls.Add(this.lblPrecioBloomberg);
            this.Controls.Add(this.label3);
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
            this.Load += new System.EventHandler(this.frmPrecioDolar_Load);
            this.Resize += new System.EventHandler(this.frmPrecioDolar_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlWeb.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPrecioBloomberg;
        private System.Windows.Forms.Label lblCierreAyerBloomberg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAperturaBloomberg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFechaBloomberg;
        private System.Windows.Forms.Panel pnlWeb;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblVentaTKambio;
        private System.Windows.Forms.Label label9;
    }
}

