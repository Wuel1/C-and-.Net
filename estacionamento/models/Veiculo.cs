using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estacionamento.models
{
    public class Veiculo
    {
        public string Name { get; set; }
        public string Mark { get; set; }

        public Veiculo(string name, string mark){
            Name = name;
            Mark = mark;
        }
    }
}