using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_de_hospedagem.models
{
    public class Suite
    {
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public int ValorDiaria { get; set; }

        public Suite(string tipo, int capacidade, int valorDiaria){
            TipoSuite = tipo;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }
        
    }
}