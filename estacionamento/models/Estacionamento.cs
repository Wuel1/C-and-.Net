using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estacionamento.models
{
    public class Estacionamento
    {
        public decimal FirstPrice { get; set; }
        public decimal HoursPrice { get; set; }
        public List<string> cars = new List<string>();

        public Estacionamento(decimal firstPrice, decimal hoursPrice){
            FirstPrice = firstPrice;
            HoursPrice = hoursPrice;
        }

        public void AddCar(string carName, string mark){
            Console.Clear();
            cars.Add(carName);
            Console.WriteLine($"O Carro de placa {carName} da marca {mark} foi adicionado ao estacionamento");
            Enter();
        }

        public void RemoveCar(string carName){
            Console.Clear();
            if(cars.Contains(carName))
            {
                cars.Remove(carName);
                Console.WriteLine($"Quantas horas o veículo de placa {carName} ficou no estacionamento?");
                _ = int.TryParse(Console.ReadLine(), out int hours);
                decimal value = FirstPrice + (hours * HoursPrice);
                Console.WriteLine($"O valor do estacionamento ficou: {value}");
            }else{
                Console.WriteLine($"O Carro de placa {carName} não foi encontrado");
            }
            Enter();
        }

        public void ListCar(){
            Console.Clear();
            Console.WriteLine("Lista de Carros");
            foreach(string car in cars){
                Console.WriteLine($" - {car}");
            }
            Enter();
        }

        private static void Enter(){
            Console.WriteLine("Aperte Enter para continuar");
            Console.ReadLine();
        }
    }
} 