using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geradorSinais
{
    public class gerador
    {
        public double amplitude, freqAmostragem, freqSinal;
        public int tipo_sinal;
        double freqAmostragem_anterior, freqAmostragem_atual;
        double amplitude_ant, amplitude_atual;
        double[] dados = new double[2];
        double aux_quadrada;
        double incremento;
        double aux_triangular = 1;
        double aux_triangular2;
        double multiplicador = 1;
        bool flag_toChangeAmplitude = false;
        bool flag_toChangeOnda = false;
        bool flag_toChangeFreqAm = false;
        int contaPontos = 0;
        public gerador(int tp_sinal, double amp, double FreqAm, double Freq)
        {
            tipo_sinal = tp_sinal;amplitude = amp;freqAmostragem = FreqAm;freqSinal = Freq;
            this.incremento = 0;
            freqAmostragem_atual = freqAmostragem; freqAmostragem_anterior = freqAmostragem;

        }
        public double[] GerarAmostra()
        {
            freqAmostragem_atual = freqAmostragem;
            double n;
            n = this.incremento / freqAmostragem;
            if (freqAmostragem_anterior != freqAmostragem_atual)
                flag_toChangeFreqAm = true;
            //verificar qual sinal é e gerar a onda
            //1 - senoidal
            //2 - triangular
            //3 - quadrada
            if (dados[0] == 0)
            {
                multiplicador = 0.5;
            }
            if (tipo_sinal == 1)
            {
                //senoidal
                if (flag_toChangeOnda)
                {
                    dados[0] = 0;
                }
                if (flag_toChangeFreqAm)
                {
                    this.incremento = 0;
                    flag_toChangeFreqAm = false;
                }
                dados[0] = amplitude * Math.Sin(2 * Math.PI * n * freqSinal);
                dados[1] = n;
                flag_toChangeOnda = true;
            }
            else if (tipo_sinal == 2)
            {
                //triangular
                amplitude_atual = amplitude;
                if (flag_toChangeOnda)
                {
                    dados[0] = 0;
                    multiplicador = 0.5;
                    contaPontos = 0;
                    flag_toChangeOnda = false;
                }
               
                if (amplitude_ant != amplitude_atual|| flag_toChangeFreqAm)
                {
                    dados[0] = 0;
                    multiplicador = 0.5;
                    contaPontos = 0;
                }
                if (flag_toChangeFreqAm)
                {
                    this.incremento = 0;
                    flag_toChangeFreqAm = false;
                }
                if (contaPontos >= multiplicador * (freqAmostragem/freqSinal) / (2.0))
                {
                    contaPontos = 0;
                    aux_triangular = -aux_triangular;
                    multiplicador = 1;
                }
                aux_triangular2 = Math.Sqrt(Math.Pow((4 * amplitude / (freqAmostragem/freqSinal)), 2) + Math.Pow((2 / (freqAmostragem/freqSinal)), 2));
                dados[0] = dados[0] + aux_triangular * aux_triangular2;
                dados[1] = n;
                contaPontos++;
                amplitude_ant = amplitude;


            }
            else if (tipo_sinal == 3)
            {
                //quadrada
                if (flag_toChangeOnda)
                {
                    dados[0] = 0;
                }
                if (flag_toChangeFreqAm)
                {
                    this.incremento = 0;
                    flag_toChangeFreqAm = false;
                }
                aux_quadrada = amplitude * Math.Sin(2 * Math.PI * n * freqSinal);
                if (aux_quadrada > 0)
                {
                    dados[0] = amplitude;
                }
                else if (aux_quadrada <= 0)
                {
                    dados[0] = -amplitude;
                }
                dados[1] = n;
                flag_toChangeOnda = true;
            }
            freqAmostragem_anterior = freqAmostragem;
            this.incremento = this.incremento + 1;
            return dados;
        }
    }
}
