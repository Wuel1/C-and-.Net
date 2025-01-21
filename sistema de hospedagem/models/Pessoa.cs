using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_de_hospedagem.models
{
    public class Pessoa
    {
        private string Name { get; set; }
        private string Sobrenome { get; set; }

        public Pessoa(string name, string sobrenome){
            Name = name;
            Sobrenome = sobrenome;
        }
        public string GetName(){
            return Name;
        }
    }
}