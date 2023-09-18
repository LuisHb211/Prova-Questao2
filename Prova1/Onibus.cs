using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1
{
    internal class Onibus : Veiculo
    {
        private int assentos;

        public Onibus (string placa,  int ano, int assentos):base(placa, ano)
        {
            this.assentos = assentos;
        }

        public int Assentos { get => assentos; set => assentos = value; }

        public override double Alugar()
        {
            int diaria = (30 * assentos) - (2023 - Ano) * 70;
            return diaria;
        }
    }

}
