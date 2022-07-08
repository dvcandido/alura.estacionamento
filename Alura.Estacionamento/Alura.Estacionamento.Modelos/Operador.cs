using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Operador
    {
        private string _nome;
        private string _matricula;

        public string Matricula { get => _matricula; set => _matricula = value; }

        public string Nome { get => _nome; set => _nome = value; }

        public Operador()
        {
            Matricula = new Guid().ToString()[..8];
        }

        public override string ToString()
        {
            return $"Operador:{Nome} \n" +
                   $"Matricula: {Matricula}";
        }
    }
}
