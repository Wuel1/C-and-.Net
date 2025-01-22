using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace abstraindo_um_smartphone.models
{
    public class Iphone : Smartphone
    {

        public decimal Ios { get; set; }

        public Iphone(string nome, string modelo, string imei, int memoria, decimal ios) : base(nome,modelo,imei,memoria)
        {
            Ios = ios;
        }

        public override void InstalarAplicativo(string nome)
        {
            Console.WriteLine($"Aplicativo {nome} instalado com sucesso no IOS {Modelo}");
        }
    }
}