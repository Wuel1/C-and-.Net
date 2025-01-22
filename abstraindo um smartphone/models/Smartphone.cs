using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace abstraindo_um_smartphone.models
{
    public abstract class Smartphone
    {
        public string Nome { get; set; }
        protected string Modelo { get; set; }
        protected string IMEI { get; set; }
        protected int Memoria { get; set; }

        public Smartphone(string nome, string modelo, string imei, int memoria)
        {
            Nome = nome;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
        }

        public void Ligar()
        {
            Console.WriteLine($"O Smartphone {Nome} está ligando");
        }

        public void ReceberLigação()
        {
            Console.WriteLine($"O Smartphone {Nome} está recebendo ligação");
        }

        public abstract void InstalarAplicativo(string nome);
    }
}