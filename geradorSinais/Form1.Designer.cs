namespace geradorSinais
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Box_sinal = new System.Windows.Forms.GroupBox();
            this.rb_quadrada = new System.Windows.Forms.RadioButton();
            this.rb_triangular = new System.Windows.Forms.RadioButton();
            this.rb_senoidal = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_amplitude = new System.Windows.Forms.TextBox();
            this.tb_freq_sinal = new System.Windows.Forms.TextBox();
            this.tb_freq_am = new System.Windows.Forms.TextBox();
            this.bt_Start = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer_gerador = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lb_qtdeBuffer = new System.Windows.Forms.Label();
            this.panel_gerador = new System.Windows.Forms.Panel();
            this.btStopGerador = new System.Windows.Forms.Button();
            this.bt_serial = new System.Windows.Forms.Button();
            this.bt_gerador = new System.Windows.Forms.Button();
            this.panel_serial = new System.Windows.Forms.Panel();
            this.lb_qtdeBuffArd = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.quantidadeBufferCircularNaSerial = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.cb_COM = new System.Windows.Forms.ComboBox();
            this.bt_conect = new System.Windows.Forms.Button();
            this.lb_bufferCapacidade = new System.Windows.Forms.Label();
            this.timer_plot = new System.Windows.Forms.Timer(this.components);
            this.timer_serial = new System.Windows.Forms.Timer(this.components);
            this.Box_sinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel_gerador.SuspendLayout();
            this.panel_serial.SuspendLayout();
            this.SuspendLayout();
            // 
            // Box_sinal
            // 
            this.Box_sinal.BackColor = System.Drawing.SystemColors.Control;
            this.Box_sinal.Controls.Add(this.rb_quadrada);
            this.Box_sinal.Controls.Add(this.rb_triangular);
            this.Box_sinal.Controls.Add(this.rb_senoidal);
            this.Box_sinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box_sinal.Location = new System.Drawing.Point(26, 3);
            this.Box_sinal.Name = "Box_sinal";
            this.Box_sinal.Size = new System.Drawing.Size(146, 146);
            this.Box_sinal.TabIndex = 0;
            this.Box_sinal.TabStop = false;
            this.Box_sinal.Text = "Sinal";
            // 
            // rb_quadrada
            // 
            this.rb_quadrada.AutoSize = true;
            this.rb_quadrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_quadrada.Location = new System.Drawing.Point(32, 95);
            this.rb_quadrada.Name = "rb_quadrada";
            this.rb_quadrada.Size = new System.Drawing.Size(91, 22);
            this.rb_quadrada.TabIndex = 2;
            this.rb_quadrada.TabStop = true;
            this.rb_quadrada.Text = "Quadrada";
            this.rb_quadrada.UseVisualStyleBackColor = true;
            // 
            // rb_triangular
            // 
            this.rb_triangular.AutoSize = true;
            this.rb_triangular.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_triangular.Location = new System.Drawing.Point(32, 67);
            this.rb_triangular.Name = "rb_triangular";
            this.rb_triangular.Size = new System.Drawing.Size(91, 22);
            this.rb_triangular.TabIndex = 1;
            this.rb_triangular.TabStop = true;
            this.rb_triangular.Text = "Triangular";
            this.rb_triangular.UseVisualStyleBackColor = true;
            // 
            // rb_senoidal
            // 
            this.rb_senoidal.AutoSize = true;
            this.rb_senoidal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_senoidal.Location = new System.Drawing.Point(32, 41);
            this.rb_senoidal.Name = "rb_senoidal";
            this.rb_senoidal.Size = new System.Drawing.Size(83, 22);
            this.rb_senoidal.TabIndex = 0;
            this.rb_senoidal.TabStop = true;
            this.rb_senoidal.Text = "Senoidal";
            this.rb_senoidal.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Amplitude:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(26, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Freq (Hz):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(25, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Freq Am (Hz):";
            // 
            // tb_amplitude
            // 
            this.tb_amplitude.Location = new System.Drawing.Point(129, 155);
            this.tb_amplitude.Name = "tb_amplitude";
            this.tb_amplitude.Size = new System.Drawing.Size(43, 20);
            this.tb_amplitude.TabIndex = 6;
            // 
            // tb_freq_sinal
            // 
            this.tb_freq_sinal.Location = new System.Drawing.Point(129, 192);
            this.tb_freq_sinal.Name = "tb_freq_sinal";
            this.tb_freq_sinal.Size = new System.Drawing.Size(43, 20);
            this.tb_freq_sinal.TabIndex = 7;
            // 
            // tb_freq_am
            // 
            this.tb_freq_am.Location = new System.Drawing.Point(129, 230);
            this.tb_freq_am.Name = "tb_freq_am";
            this.tb_freq_am.Size = new System.Drawing.Size(43, 20);
            this.tb_freq_am.TabIndex = 8;
            this.tb_freq_am.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_freq_am_KeyPress);
            // 
            // bt_Start
            // 
            this.bt_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.bt_Start.Location = new System.Drawing.Point(29, 262);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(143, 46);
            this.bt_Start.TabIndex = 9;
            this.bt_Start.Text = "Start";
            this.bt_Start.UseVisualStyleBackColor = false;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(233, -3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(678, 555);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // timer_gerador
            // 
            this.timer_gerador.Interval = 10;
            this.timer_gerador.Tick += new System.EventHandler(this.timer_gerador_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ocupação do Buffer:";
            // 
            // lb_qtdeBuffer
            // 
            this.lb_qtdeBuffer.AutoSize = true;
            this.lb_qtdeBuffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_qtdeBuffer.Location = new System.Drawing.Point(172, 378);
            this.lb_qtdeBuffer.Name = "lb_qtdeBuffer";
            this.lb_qtdeBuffer.Size = new System.Drawing.Size(16, 18);
            this.lb_qtdeBuffer.TabIndex = 12;
            this.lb_qtdeBuffer.Text = "0";
            // 
            // panel_gerador
            // 
            this.panel_gerador.Controls.Add(this.btStopGerador);
            this.panel_gerador.Controls.Add(this.label3);
            this.panel_gerador.Controls.Add(this.lb_qtdeBuffer);
            this.panel_gerador.Controls.Add(this.Box_sinal);
            this.panel_gerador.Controls.Add(this.label4);
            this.panel_gerador.Controls.Add(this.label1);
            this.panel_gerador.Controls.Add(this.label2);
            this.panel_gerador.Controls.Add(this.bt_Start);
            this.panel_gerador.Controls.Add(this.tb_amplitude);
            this.panel_gerador.Controls.Add(this.tb_freq_am);
            this.panel_gerador.Controls.Add(this.tb_freq_sinal);
            this.panel_gerador.Location = new System.Drawing.Point(12, 105);
            this.panel_gerador.Name = "panel_gerador";
            this.panel_gerador.Size = new System.Drawing.Size(200, 405);
            this.panel_gerador.TabIndex = 13;
            // 
            // btStopGerador
            // 
            this.btStopGerador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btStopGerador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btStopGerador.Location = new System.Drawing.Point(29, 314);
            this.btStopGerador.Name = "btStopGerador";
            this.btStopGerador.Size = new System.Drawing.Size(143, 46);
            this.btStopGerador.TabIndex = 13;
            this.btStopGerador.Text = "Stop";
            this.btStopGerador.UseVisualStyleBackColor = false;
            this.btStopGerador.Click += new System.EventHandler(this.btStopGerador_Click);
            // 
            // bt_serial
            // 
            this.bt_serial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.bt_serial.Location = new System.Drawing.Point(12, 12);
            this.bt_serial.Name = "bt_serial";
            this.bt_serial.Size = new System.Drawing.Size(200, 38);
            this.bt_serial.TabIndex = 14;
            this.bt_serial.Text = "Serial";
            this.bt_serial.UseVisualStyleBackColor = true;
            this.bt_serial.Click += new System.EventHandler(this.bt_serial_Click);
            // 
            // bt_gerador
            // 
            this.bt_gerador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.bt_gerador.Location = new System.Drawing.Point(12, 56);
            this.bt_gerador.Name = "bt_gerador";
            this.bt_gerador.Size = new System.Drawing.Size(200, 38);
            this.bt_gerador.TabIndex = 15;
            this.bt_gerador.Text = "Gerador";
            this.bt_gerador.UseVisualStyleBackColor = true;
            this.bt_gerador.Click += new System.EventHandler(this.bt_gerador_Click);
            // 
            // panel_serial
            // 
            this.panel_serial.Controls.Add(this.lb_qtdeBuffArd);
            this.panel_serial.Controls.Add(this.label6);
            this.panel_serial.Controls.Add(this.quantidadeBufferCircularNaSerial);
            this.panel_serial.Controls.Add(this.label5);
            this.panel_serial.Controls.Add(this.btStop);
            this.panel_serial.Controls.Add(this.btStart);
            this.panel_serial.Controls.Add(this.cb_COM);
            this.panel_serial.Controls.Add(this.bt_conect);
            this.panel_serial.Location = new System.Drawing.Point(15, 100);
            this.panel_serial.Name = "panel_serial";
            this.panel_serial.Size = new System.Drawing.Size(204, 327);
            this.panel_serial.TabIndex = 13;
            // 
            // lb_qtdeBuffArd
            // 
            this.lb_qtdeBuffArd.AutoSize = true;
            this.lb_qtdeBuffArd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_qtdeBuffArd.Location = new System.Drawing.Point(132, 255);
            this.lb_qtdeBuffArd.Name = "lb_qtdeBuffArd";
            this.lb_qtdeBuffArd.Size = new System.Drawing.Size(17, 18);
            this.lb_qtdeBuffArd.TabIndex = 7;
            this.lb_qtdeBuffArd.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Quantidade Buffer Ard: ";
            // 
            // quantidadeBufferCircularNaSerial
            // 
            this.quantidadeBufferCircularNaSerial.AutoSize = true;
            this.quantidadeBufferCircularNaSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantidadeBufferCircularNaSerial.Location = new System.Drawing.Point(155, 214);
            this.quantidadeBufferCircularNaSerial.Name = "quantidadeBufferCircularNaSerial";
            this.quantidadeBufferCircularNaSerial.Size = new System.Drawing.Size(17, 18);
            this.quantidadeBufferCircularNaSerial.TabIndex = 5;
            this.quantidadeBufferCircularNaSerial.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quantidade Buffer:";
            // 
            // btStop
            // 
            this.btStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btStop.Location = new System.Drawing.Point(19, 123);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(160, 49);
            this.btStop.TabIndex = 3;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = false;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btStart.Location = new System.Drawing.Point(19, 68);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(160, 49);
            this.btStart.TabIndex = 2;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // cb_COM
            // 
            this.cb_COM.FormattingEnabled = true;
            this.cb_COM.Location = new System.Drawing.Point(3, 22);
            this.cb_COM.Name = "cb_COM";
            this.cb_COM.Size = new System.Drawing.Size(121, 21);
            this.cb_COM.TabIndex = 1;
            // 
            // bt_conect
            // 
            this.bt_conect.Location = new System.Drawing.Point(126, 22);
            this.bt_conect.Name = "bt_conect";
            this.bt_conect.Size = new System.Drawing.Size(75, 23);
            this.bt_conect.TabIndex = 0;
            this.bt_conect.Text = "Conectar";
            this.bt_conect.UseVisualStyleBackColor = true;
            this.bt_conect.Click += new System.EventHandler(this.bt_conect_Click);
            // 
            // lb_bufferCapacidade
            // 
            this.lb_bufferCapacidade.AutoSize = true;
            this.lb_bufferCapacidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bufferCapacidade.Location = new System.Drawing.Point(2, 526);
            this.lb_bufferCapacidade.Name = "lb_bufferCapacidade";
            this.lb_bufferCapacidade.Size = new System.Drawing.Size(225, 18);
            this.lb_bufferCapacidade.TabIndex = 16;
            this.lb_bufferCapacidade.Text = "Buffer Dentro da Capacidade";
            // 
            // timer_plot
            // 
            this.timer_plot.Interval = 10;
            this.timer_plot.Tick += new System.EventHandler(this.timer_plot_Tick);
            // 
            // timer_serial
            // 
            this.timer_serial.Interval = 50;
            this.timer_serial.Tick += new System.EventHandler(this.timer_serial_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 553);
            this.Controls.Add(this.lb_bufferCapacidade);
            this.Controls.Add(this.panel_serial);
            this.Controls.Add(this.bt_gerador);
            this.Controls.Add(this.bt_serial);
            this.Controls.Add(this.panel_gerador);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Box_sinal.ResumeLayout(false);
            this.Box_sinal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel_gerador.ResumeLayout(false);
            this.panel_gerador.PerformLayout();
            this.panel_serial.ResumeLayout(false);
            this.panel_serial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Box_sinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_amplitude;
        private System.Windows.Forms.TextBox tb_freq_sinal;
        private System.Windows.Forms.TextBox tb_freq_am;
        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.RadioButton rb_quadrada;
        private System.Windows.Forms.RadioButton rb_triangular;
        private System.Windows.Forms.RadioButton rb_senoidal;
        private System.Windows.Forms.Timer timer_gerador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_qtdeBuffer;
        private System.Windows.Forms.Panel panel_gerador;
        private System.Windows.Forms.Button bt_serial;
        private System.Windows.Forms.Button bt_gerador;
        private System.Windows.Forms.Panel panel_serial;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.ComboBox cb_COM;
        private System.Windows.Forms.Button bt_conect;
        private System.Windows.Forms.Button btStopGerador;
        private System.Windows.Forms.Label quantidadeBufferCircularNaSerial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_bufferCapacidade;
        private System.Windows.Forms.Label lb_qtdeBuffArd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer_plot;
        private System.Windows.Forms.Timer timer_serial;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

