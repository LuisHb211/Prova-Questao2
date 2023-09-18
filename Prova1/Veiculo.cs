using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1
{
    public abstract class Veiculo
    {
        private string placa;
        private int ano;

        public Veiculo(string placa, int ano)
        {
            this.placa = placa;
            this.ano = ano;
        }
        public string Placa { get => placa; set => placa = value; }
        public int Ano { get => ano; set => ano = value; }

        public virtual double Alugar()
        {
            return 0.0;
        }

    }
}
