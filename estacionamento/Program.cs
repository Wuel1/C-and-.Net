using estacionamento.models;

class Program{
    public static void Main(String[] args) {

        decimal firstPrice;
        decimal hoursPrice;

        Console.WriteLine("Seja bem Vindo ao sistema do Estacionamento\n" + 
                            "Digite o Preço inicial:");
        
        firstPrice = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine($"O preço incial é: R${firstPrice} reais");

        Console.WriteLine("Agora digite o preço por hora");

        hoursPrice = Convert.ToDecimal(Console.ReadLine());

        // Iniciando uma instância de um estacionamento
        Estacionamento parking = new Estacionamento(firstPrice, hoursPrice);

        bool menu = true;

        while(menu){
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao Estacionamento Wuel\n" + "Selecione uma das opções abaixo:");
            Console.WriteLine("1 - Adicionar Veículo");
            Console.WriteLine("2 - Remover Veículo");
            Console.WriteLine("3 - Listar Veículos");
            Console.WriteLine("4 - Sair");

            int controller;
            controller = Convert.ToInt16(Console.ReadLine());

            // Adiciona Carro
            if(controller == 1)
            {
                Console.WriteLine("Digite a placa do veículo:");
                string? name = Console.ReadLine();
                Console.WriteLine("Digite a marca do veículo:");
                string? mark = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(mark)){
                    Console.WriteLine("Por favor, preencha todos os campos corretamente");
                    Console.ReadKey();
                    continue;
                }
                Veiculo vehicle =  new Veiculo(name, mark);
                parking.AddCar(vehicle);
                continue;
            }
            
            // Remove Carro
            if(controller == 2)
            {
                Console.WriteLine("Digite a placa do carro que você quer retirar");
                string? name = Console.ReadLine();
                
                if(string.IsNullOrWhiteSpace(name)){
                    Console.WriteLine("Por favor, preencha todos os campos corretamente");
                    Console.ReadKey();
                    continue;
                }

                parking.RemoveCar(name);
                continue;
            }
            
            // Lista Carros
            if(controller == 3)
            {
                parking.ListCar();
                continue;
            }

            // Sair
            if(controller == 4)
            {
                menu = false;
            }
        }
    }
}