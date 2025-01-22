using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace abstraindo_um_smartphone.models
{
    public class Nokia : Smartphone
    {
        public decimal Android { get; set; }

        public Nokia(string nome, string modelo, string imei, int memoria, decimal android) : base(nome, modelo, imei, memoria)
        {
            Android = android;
        }

        public override void InstalarAplicativo(string nome)
        {
            Console.WriteLine($"Aplicativo {nome} instalado com sucesso no Android {Android}");
        }
    }
}