using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geradorSinais
{
    class BufferCircular
    {
        double[,] buffer;
        public int tamBuffer;
        public int contAmostra;
        int PWR, PRD;
        public BufferCircular(int tamanho)
        {
            tamBuffer = tamanho;
            buffer = new double[tamanho,2];
            PWR = 0; PRD = 0;contAmostra = 0;
        }
        public bool push(double[] valor)
        {
            bool resposta = true;
            buffer[PWR,0] = valor[0];
            buffer[PWR,1] = valor[1];
            if (contAmostra >= tamBuffer - 1)//verifica sobrescrevimento
            {
                resposta = false;
            }
            else
            {
                contAmostra++;
            }
            PWR++;
            if (PWR >= tamBuffer - 1)//circular
                PWR = 0;
            return resposta;
        }
        public bool pop(ref double[] valor)
        {
            if (contAmostra == 0)
                return false;
            else
            {
                valor[0] = buffer[PRD, 0];
                valor[1] = buffer[PRD, 1];
                contAmostra--;
                PRD++;
            }
            if(PRD>=tamBuffer-1)
            {
                PRD = 0;
            }
            return true;
        }

    }
}
