using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_de_hospedagem.models
{
    public class Reserva
    {
        private List<Pessoa> Hospedes { get; set; }
        private Suite Suite {get; set;}
        private int DiasReservados { get; set; }

        public Reserva(List<Pessoa> hospedes, Suite suite, int diasReservados)
        {
            Hospedes = hospedes;
            Suite = suite;
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            foreach (Pessoa pessoa in hospedes)
            {
                Hospedes.Add(pessoa);
            }
        }
        
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public int CalculaValorDiaria()
        {
            if(DiasReservados >= 10){
                return (int)(Suite.ValorDiaria * DiasReservados * 0.9);
            }
            return Suite.ValorDiaria * DiasReservados;
        }
        
    }
}