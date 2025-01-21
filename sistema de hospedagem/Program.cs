using sistema_de_hospedagem.models;

class Program(){
    public static void Main(String[] args) {
        while(true)
        {
            int menu;
            Console.WriteLine("Bem vindo ao sistema de hotelaria Wuel");
            Console.WriteLine("Por favor, Selecione uma das opções abaixo");
            Console.WriteLine("1 - Cadastrar Pessoa");
            Console.WriteLine("2 - Cadastrar Suite");
            Console.WriteLine("3 - Listar Suite");
            Console.WriteLine("4 - Fazer Reserva");
            Console.WriteLine("5 - Verificar Reservas");

            menu = GetValidInt();

            if(menu == 1)
            {
                Console.Clear();
                int numeroHospedes;
                List<Pessoa> listaHospedes = new List<Pessoa>();

                Console.WriteLine("Quantas Pessoas você deseja cadastrar?");

                numeroHospedes = GetValidInt();

                for(int i = 0; i < numeroHospedes; i++){
                    string? nome;
                    string? sobrenome;

                    Console.WriteLine($"Digite o primeiro nome:{i+1}");
                    nome = Console.ReadLine();
                    Console.WriteLine($"Digite o sobrenome:{i+1}");
                    sobrenome = Console.ReadLine();

                    Pessoa pessoa = new Pessoa(nome, sobrenome);
                    listaHospedes.Add(pessoa);
                }
                Console.WriteLine($"{numeroHospedes} Hospedes cadastrados com sucesso");
                Enter();
            }
            if(menu == 2)
            {
                Console.Clear();
                string tipo;
                int capacidade;
                int valorDiaria;

                Console.WriteLine("Digite qual tipo de suíte\n1 - Premium\n 2 - Casual");
                int chave = GetValidInt();
                tipo = (chave == 1)? "Premium" : "Casual";
                Console.WriteLine("Digite a capacidade da suíte");
                capacidade = GetValidInt();
                Console.WriteLine("Digite o valor da diária da suíte");
                valorDiaria = GetValidInt();

                Suite suite = new Suite(tipo, capacidade, valorDiaria);

                Console.WriteLine($"Suite do tipo {suite.TipoSuite} com capacidade de {suite.Capacidade} hospedes e com valor\nde       diária de R$({suite.ValorDiaria}:F2) criada com sucesso");
            }
        }
    }

    private static int GetValidInt(){
        while (true){
            if (int.TryParse(Console.ReadLine(), out int value)){
                return value;
            }
            Console.WriteLine("Por favor, digite um valor válido");
        }
    }

    private static void Enter(){
        Console.WriteLine("Aperter Enter para continuar");
        Console.ReadLine();
    }
}