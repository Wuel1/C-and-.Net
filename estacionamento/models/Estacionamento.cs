using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estacionamento.models
{
    public class Estacionamento
    {
        private decimal FirstPrice { get; set; }
        private decimal HoursPrice { get; set; }
        private List<Veiculo> vehicles = new List<Veiculo>();

        public Estacionamento(decimal firstPrice, decimal hoursPrice){
            FirstPrice = firstPrice;
            HoursPrice = hoursPrice;
        }

        public void AddCar(Veiculo vehicle){
            Console.Clear();
            vehicles.Add(vehicle);
            Console.WriteLine($"O Carro de placa {vehicle.Name} da marca {vehicle.Mark} foi adicionado ao estacionamento");
            Enter();
        }

        public void RemoveCar(string name){
            Console.Clear();
            for(int i = 0; i < vehicles.Count(); i++){
                if(vehicles[i].Name == name){
                    int hours = GetValidInt($"Quantas horas o veículo de placa {vehicles[i].Name} ficou no estacionamento?");
                    decimal value = FirstPrice + (hours * HoursPrice);
                    Console.WriteLine($"O valor do estacionamento ficou: {value:F2}");
                    vehicles.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine($"O veículo de placa {name} não foi encontrado");
            Enter();
        }

        public void ListCar(){
            Console.Clear();
            Console.WriteLine("Lista de Carros");
            foreach(Veiculo car in vehicles){
                Console.WriteLine($" => {car.Name} - {car.Mark}"); 
            }
            Enter();
        }

        private static void Enter(){
            Console.WriteLine("Aperte Enter para continuar");
            Console.ReadLine();
        }

        private static int GetValidInt(string message){
            Console.WriteLine(message);
            while (true){
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                Console.WriteLine("Valor inválido, tente novamente");
            }
        }
    }
}