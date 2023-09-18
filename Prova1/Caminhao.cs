using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1
{
    internal class Caminhao : Veiculo
    {
        private int eixos;

        public Caminhao(string placa, int ano, int eixos) : base(placa, ano)
        {
            this.eixos = eixos;
        }

        public int Eixos { get => eixos; set => eixos = value; }

        public override double Alugar()
        {
            int diaria = (300 * eixos) - (2023 - Ano) * 50;
            return diaria;
        }
    }

}
