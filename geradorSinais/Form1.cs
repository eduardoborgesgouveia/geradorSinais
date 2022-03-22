using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace geradorSinais
{
    public partial class Form1 : Form
    {
        //variaveis dos pacotes
        int vPL;
        int vST;
        int vET;
        //variaveis bytes
        ushort feed16;
        ushort feed1_16;
        ushort feed2;
        double tensao;

        FFT2 doFFT;
        int numeroDeCiclos = 3;
        uint nfft = 0;
        double[] auxiliar = new double[2];
        Mutex m;
        public int contadorParaFFT = 0;
        public int banana = 0;
        public int tamanhoJanelaFFT = 0;
        public double[] vetorParaPlotarFFT;

        Thread aquisicao, plot, FFT;
        static double GlobalValMaxAxisX;
        static double GlobalValMinAxisX;
        static int GlobalSeriesCont;
        static double pto_x, pto_y;
        public static double interval = 0;
        SerialPort serial;
        double frequenciaAmostragem, frequenciaSinal, amplitude;
        int tipo_sinal;
        gerador sinal;
        double[] dados = new double[2];
        double count = 0;
        public static Series serieGrafico, serieFFT;
        public static ChartArea areaGrafico, areaFFT;
        
        double temp;
        double freqAmostragem_anterior, freqAmostragem_atual;
        bool flag_Plot = false;
        int nyquist = 0;
        int qtdeAmostraBuffer;
        BufferCircular BC;
        BufferCircular BufferFFT;
        double tempo = 0;
        bool flag_thread_plot = false;
        bool flag_thread_serial = false;
        bool flagToSolveAllTheProblems = false;
        bool flag_to_fft = false;
        public static bool flag_to_set_axis = false;
        public bool flag_to_get_axis = true;
        
        /// <summary>
        /// Essa função é utilizada para utilizar elementos gráficos juntamente com threads
        /// A função setLabel deve ser chamada dentro da thread.
        /// Na linha "delegateHandler_setTextLabel = new setTextLabelDelegate(setTextLabelWithDelegate);"
        /// a funçao que "setTextLabelWithDelegate" deve ser especifica para cada elemento gráfico.
        /// Deve-se criar a função "setTextLabelWithDelegate" e nela colocar a atribuição
        /// </summary>
        /// <param name="s">string que será colocada na label</param>
        public void setLabelQtdeBufferArd(string s)
        {
            if(lb_qtdeBuffArd.InvokeRequired)
            {
                delegateHandler_setTextLabel = new setTextLabelDelegate(setTextLabelBuffArdWithDelegate);
                lb_qtdeBuffArd.BeginInvoke(delegateHandler_setTextLabel, new object[] { s });
            }
            else
            {
                lb_qtdeBuffArd.Text = s;
            }
        }

        public delegate void setTextLabelDelegate(string s);
        public setTextLabelDelegate delegateHandler_setTextLabel;
        private void setTextLabelBuffArdWithDelegate(string s)
        {
            lb_qtdeBuffArd.Text = s;
        }



        //Atribuindo ao label QtdeBufferCircular o valor da mesma
        public void setLabelQtdeBufferCircular(string s)
        {
            if (lb_qtdeBuffer.InvokeRequired)
            {
                delegateHandler_setTextLabel = new setTextLabelDelegate(setTextLabelQtdeBufferWithDelegate);
                lb_qtdeBuffer.BeginInvoke(delegateHandler_setTextLabel, new object[] { s });
            }
            else
            {
                lb_qtdeBuffer.Text = s;
            }
        }
        private void setTextLabelQtdeBufferWithDelegate(string s)
        {
            lb_qtdeBuffer.Text = s;
        }
        //Atribuindo ao label QtdeBufferCircularNaSerial o valor da mesma
        public void setLabelQtdeBufferCircularNaSerial(string s)
        {
            if (quantidadeBufferCircularNaSerial.InvokeRequired)
            {
                delegateHandler_setTextLabel = new setTextLabelDelegate(setTextLabelQtdeBufferNaSerialWithDelegate);
                quantidadeBufferCircularNaSerial.BeginInvoke(delegateHandler_setTextLabel, new object[] { s });
            }
            else
            {
                quantidadeBufferCircularNaSerial.Text = s;
            }
        }
        private void setTextLabelQtdeBufferNaSerialWithDelegate(string s)
        {
            quantidadeBufferCircularNaSerial.Text = s;
        }


        //Tentativa de fazer um delegate para o valor máximo do eixo X do Chart
        public delegate void VarDouble(double x);
        //criando a função de atribuição
        static void setVarMaxDouble_WithDelegate(double x)
        {
            GlobalValMaxAxisX = x;
            //areaGrafico.AxisX.Maximum = x;
        }
        //Criando uma "função" do tipo setVarInt_WithDelegate
        VarDouble set_VarMax = setVarMaxDouble_WithDelegate;

        //Tentativa de fazer outro delegate para o valor mínimo do eixo X do Chart
        //criando a função de atribuição
        static void setVarMinDouble_WithDelegate(double x)
        {
            GlobalValMinAxisX = x;
        }
        //Criando uma "função" do tipo setVarInt_WithDelegate
        VarDouble set_VarMin = setVarMinDouble_WithDelegate;




        //Tentativa de atribuir pontos ao gráfico com delegate
        delegate void VarDoublePto(double[] val);
        static void atribuirPto_WithDelegate(double[] val)
        {

            if (val[1] > areaGrafico.AxisX.Maximum)
            {
                if (serieGrafico.Points.Count > 0)
                {
                    serieGrafico.Points.RemoveAt(0);
                }
                areaGrafico.AxisX.Maximum = val[1] + interval;
                areaGrafico.AxisX.Minimum = interval + areaGrafico.AxisX.Minimum;
                areaGrafico.AxisX.RoundAxisValues();
                areaGrafico.AxisX.LabelStyle.Format = "#";
            }
            serieGrafico.Points.AddXY(val[1], val[0]);
           

        }
        VarDoublePto add_Pto;

        //Tentativa de atribuir pontos ao gráfico com delegate
        delegate void ptoFFT(double[,] valFFT);
        static void atribuirPtoFFT_WithDelegate(double[,] valFFT)
        {
            serieFFT.Points.Clear();
            for (int ii = 0; ii < valFFT.Length/2; ii++)
            {
                serieFFT.Points.AddXY(valFFT[ii, 1], valFFT[ii, 0]);
            }
        }
        ptoFFT add_PtoFFT;



        //Thread aquisição de dados pela porta Serial
        void thread_serial()
        {
            while (flag_thread_serial)
            {
                int N = serial.BytesToRead;
                setLabelQtdeBufferArd(Convert.ToString(N));
                if (N >= 1)
                {
                    for (int j = 0; j < N; j++)
                    {
                        //Esperando pelo ST (Start)
                        while (flag_thread_plot)
                        {
                            if (N >= 1)
                            {
                                vST = Convert.ToByte(serial.ReadByte());
                                if (vST == 0x53)
                                {
                                    break;
                                }
                            }
                            //verificando o PL
                            if (N >= 1)
                            {
                                vPL = Convert.ToByte(serial.ReadByte());
                                if (vPL == 2)
                                {
                                    feed16 = Convert.ToByte(serial.ReadByte());
                                    int x = (int)(feed16 << 8);
                                    feed1_16 = Convert.ToByte(serial.ReadByte());
                                    feed2 = Convert.ToUInt16(x | feed1_16);
                                    tensao = feed2 * (3.3 / 4096);
                                }
                            }
                            if (N >= 1)
                            {
                                vET = Convert.ToByte(serial.ReadByte());
                                if (vET == 0x04)
                                {
                                    dados[0] = tensao;
                                    tempo = tempo + interval;
                                    dados[1] = tempo;
                                    BC.push(dados);
                                    BufferFFT.push(dados);
                                }
                            }
                        }
                    }
                }
            }

        }
        
        //Thread para plotagem
        void thread_plot() 
        {
            while (flag_thread_plot)
            {
                m.WaitOne();
                if (BC.pop(ref dados))
                {
                    vetorParaPlotarFFT[contadorParaFFT] = dados[0];
                    if (chart1.InvokeRequired)
                    {
                        add_Pto = new VarDoublePto(atribuirPto_WithDelegate);
                        chart1.BeginInvoke(add_Pto, new object[] { dados });
                        qtdeAmostraBuffer = BC.contAmostra;
                        setLabelQtdeBufferCircularNaSerial(Convert.ToString(qtdeAmostraBuffer));
                        setLabelQtdeBufferCircular(Convert.ToString(qtdeAmostraBuffer));
                    }
                    contadorParaFFT++;
                }
                m.ReleaseMutex();
            }
        }



        //Thread para plotagem da FFT
        void thread_FFT()
        {
            while(flag_to_fft)
            {
                if (tamanhoJanelaFFT == contadorParaFFT)
                {
                    m.WaitOne();
                    int fftWindow = (int)Math.Pow(2, nfft); //2^n onde n é o número de bits nos dá a janela da FFT, porém o resultado de FFT's é metade desses valores.
                    double[] realFFT = new double[fftWindow];
                    double[] imFFT = new double[fftWindow];
                    for (int i = 0; i < fftWindow; i++)
                    {
                        realFFT[i] = vetorParaPlotarFFT[i];
                        imFFT[i] = 0;
                    }
                    doFFT.init(nfft);
                    doFFT.run(realFFT, imFFT);
                    double[,] powAndXFFT = new double[(fftWindow / 2), 2];
                    for (int i = 0; i < fftWindow / 2; i++)
                    {
                        powAndXFFT[i, 0] = Math.Sqrt(realFFT[i] * realFFT[i] + imFFT[i] * imFFT[i]);
                        powAndXFFT[i, 1] = (sinal.freqAmostragem * i) / fftWindow;
                    }
                    if (chart1.InvokeRequired)
                    {
                        add_PtoFFT = new ptoFFT(atribuirPtoFFT_WithDelegate);
                        chart1.BeginInvoke(add_PtoFFT, new object[] { powAndXFFT });
                    }
                    contadorParaFFT = 0;
                    m.ReleaseMutex();
                }
            }
        }


        private void timer_plot_Tick(object sender, EventArgs e)
        {
        }

        private void tb_freq_am_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                
                if (tb_freq_am.Text != "")
                {
                    sinal.freqAmostragem = Convert.ToInt16(tb_freq_am.Text);
                }
                serieGrafico.Points.Clear();
                areaGrafico.AxisX.Minimum = 0;
                areaGrafico.AxisX.Maximum = 5;
            }
        }

        private void bt_serial_Click(object sender, EventArgs e)
        {
            panel_gerador.Hide();
            panel_serial.Show();
            cb_COM.Items.AddRange(SerialPort.GetPortNames());

        }

        private void bt_gerador_Click(object sender, EventArgs e)
        {
            panel_serial.Hide();
            panel_gerador.Show();
        }

        private void timer_serial_Tick(object sender, EventArgs e)
        {
            
        }

        private void bt_conect_Click(object sender, EventArgs e)
        {
            //abrir a conexao com a porta COM selecionada na combobox
            string portName = cb_COM.Items[cb_COM.SelectedIndex].ToString();
            //abre a comunicação com a porta serial
            serial.PortName = portName;
            serial.BaudRate = 57600;
            serial.Open();
        }
        //Start GERADOR
        private void bt_Start_Click(object sender, EventArgs e)
        {
            flag_to_fft = true;
            flag_thread_plot = true;
            nfft = Convert.ToUInt16(Math.Log(sinal.freqAmostragem, 2));
            vetorParaPlotarFFT = new double[(int)Math.Pow(2, nfft)];
            tamanhoJanelaFFT = (int)Math.Pow(2, nfft);
            interval = nyquist / sinal.freqAmostragem;
            plot.Start();
            FFT.Start();
            timer_gerador.Start();
        }
        //Start SERIAL
        private void btStart_Click(object sender, EventArgs e)
        {          
            timer_plot.Start();
            flag_thread_plot = true;
            flag_thread_serial = true;
            flag_to_fft = true;
            plot.Start();
            FFT.Start();
            areaGrafico.AxisY.Minimum = 0;
            areaGrafico.AxisY.Maximum = 4;
            interval = 0.01; ///frequencia do arduino é 20Hz
            double freqSinalArduino = 1 / interval;
            nfft = Convert.ToUInt16(Math.Log(freqSinalArduino, 2));
            vetorParaPlotarFFT = new double[(int)Math.Pow(2,nfft)];
            tamanhoJanelaFFT = (int)Math.Pow(2,nfft);
            aquisicao.Start();
            dados[0] = 0;
            dados[1] = 0;
        }
        //STOP serial
        private void btStop_Click(object sender, EventArgs e)
        {
            //timer_serial.Stop();
            timer_plot.Stop();
            flag_thread_plot = false;
            flag_thread_serial = false;
            if (serial.IsOpen)
                serial.Close();
        }
        //STOP gerador
        private void btStopGerador_Click(object sender, EventArgs e)
        {
            timer_gerador.Stop();
            flag_thread_plot = false;
            flag_to_fft = false;
                    
        }

        public Form1()
        {
           
            InitializeComponent();
    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_gerador.Hide();
            panel_serial.Hide();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            serieGrafico = new Series("Sinal");
            serieGrafico.ChartType = SeriesChartType.FastLine;
            serieGrafico.BorderWidth = 3;
            serieFFT = new Series("FFT");
            serieFFT.ChartType = SeriesChartType.FastLine;
            serieFFT.BorderWidth = 3;
            chart1.Series.Add(serieGrafico);
            chart1.Series.Add(serieFFT);
            areaGrafico = new ChartArea("AreaGerador");
            areaGrafico.AxisX.Title = "Tempo (s)";
            areaGrafico.AxisY.Title = "Amplitude (V)";
            areaGrafico.AxisX.Minimum = 0;
            areaGrafico.AxisX.Maximum = 1;
            areaFFT = new ChartArea("AreaFFT");
            areaFFT.AxisX.Title = "Frequencia (Hz)";
            areaFFT.AxisY.Title = "Amplitude (V?)";
            GlobalValMaxAxisX = areaGrafico.AxisX.Maximum;
            GlobalValMinAxisX = areaGrafico.AxisX.Minimum;
            GlobalSeriesCont = serieGrafico.Points.Count;
            areaGrafico.AxisX.RoundAxisValues();
            areaGrafico.AxisX.LabelStyle.Format = "#";
            areaFFT.AxisX.Minimum = 0;
            areaFFT.AxisX.RoundAxisValues();
            areaFFT.AxisX.LabelStyle.Format = "#";
            chart1.ChartAreas.Add(areaGrafico);
            chart1.ChartAreas.Add(areaFFT);
            chart1.Series["Sinal"].ChartArea = "AreaGerador";
            chart1.Series["FFT"].ChartArea = "AreaFFT";
            tb_amplitude.Text = "1";
            tb_freq_am.Text = "100";
            tb_freq_sinal.Text = "1";
            nyquist = 5;
            sinal = new gerador(tipo_sinal, amplitude, frequenciaAmostragem, frequenciaSinal);
            BC = new BufferCircular(10000);
            if (tb_freq_am.Text != "")
            {
                sinal.freqAmostragem = Convert.ToInt16(tb_freq_am.Text);
            }
            BufferFFT = new BufferCircular((int)(sinal.freqAmostragem) * numeroDeCiclos);
            serial = new SerialPort();
            aquisicao = new Thread(thread_serial);
            aquisicao.Priority = ThreadPriority.Normal;
            plot = new Thread(thread_plot);
            plot.Priority = ThreadPriority.Normal;
            FFT = new Thread(thread_FFT);
            FFT.Priority = ThreadPriority.Normal;
            doFFT = new FFT2();
            m = new Mutex();
            
            
            
        }

        private void timer_gerador_Tick(object sender, EventArgs e)
        {
            
            if (rb_senoidal.Checked == true)
                sinal.tipo_sinal = 1;
            else if (rb_triangular.Checked == true)
                sinal.tipo_sinal = 2;
            else if (rb_quadrada.Checked == true)
                sinal.tipo_sinal = 3;
            
            if (tb_freq_sinal.Text != "")
            {
                sinal.freqSinal = Convert.ToInt16(tb_freq_sinal.Text);
            }
            if (tb_amplitude.Text != "")
            {
                sinal.amplitude = Convert.ToInt16(tb_amplitude.Text);
            }
            dados = sinal.GerarAmostra();
            if (!BC.push(dados))
            {
                lb_bufferCapacidade.Text = "Buffer Lotado";
                lb_bufferCapacidade.ForeColor = Color.Red;
                timer_gerador.Stop();
                flag_thread_plot = false;
                flag_to_fft = false;
            }

            areaGrafico.AxisY.Minimum = -1.5*sinal.amplitude;
            areaGrafico.AxisY.Maximum = +1.5*sinal.amplitude;


        }
    }
}
