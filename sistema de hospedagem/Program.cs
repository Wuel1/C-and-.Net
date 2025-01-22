using sistema_de_hospedagem.models;

class Program(){
    public static void Main(String[] args) {
        List<Suite> suites = new List<Suite>();
        List<Pessoa> listaHospedes = new List<Pessoa>();
        List<Reserva> listaReservas = new List<Reserva>();

        while(true)
        {
            int menu;
            Console.Clear();
            Console.WriteLine("Bem vindo ao sistema de hotelaria Wuel");
            Console.WriteLine("Por favor, Selecione uma das opções abaixo");
            Console.WriteLine("1 - Cadastrar Pessoa");
            Console.WriteLine("2 - Cadastrar Suite");
            Console.WriteLine("3 - Listar Suites");
            Console.WriteLine("4 - Fazer Reserva");
            Console.WriteLine("5 - Verificar Reservas");

            menu = GetValidInt();

            if(menu == 1)
            {
                Console.Clear();
                int numeroHospedes;

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

                Console.WriteLine("Digite qual tipo de suíte\n1 - Premium\n2 - Casual");
                int chave = GetValidInt();
                tipo = (chave == 1)? "Premium" : "Casual";
                Console.WriteLine("Digite a capacidade da suíte");
                capacidade = GetValidInt();
                Console.WriteLine("Digite o valor da diária da suíte");
                valorDiaria = GetValidInt();

                Suite suite = new Suite(tipo, capacidade, valorDiaria);
                suites.Add(suite);

                Console.WriteLine($"Suite do tipo {suite.TipoSuite} com capacidade de {suite.Capacidade} hospedes e com valor de       diária de R${suite.ValorDiaria:F2} criada com sucesso");
                Enter();
            }
            if(menu == 3)
            {
                Console.Clear();
                foreach(Suite suite in suites){
                    Console.WriteLine($"Tipo: {suite.TipoSuite} - Capacidade: {suite.Capacidade} - Valor diária: {suite.ValorDiaria}");
                }
                Enter();
            }
            if(menu == 4)
            {
                Console.Clear();
                Console.WriteLine($"Você tem {listaHospedes.Count()} cadastrados e prontos para reserva");
                Console.WriteLine("Em qual suite você deseja fazer a sua reserva?");
                for(int i = 0; i < suites.Count; i++){
                    Console.WriteLine($"{i+1} - {suites[i].TipoSuite} - Capacidade:{suites[i].Capacidade} - Valor diária{suites[i].ValorDiaria}");
                }
                int chave = GetValidInt();
                Console.WriteLine("Quantos dias você deseja passar?");
                int dias = GetValidInt();
                Reserva reserva = new Reserva(listaHospedes, suites[chave-1], dias);
                listaReservas.Add(reserva);
                Console.WriteLine($"Reserva de {dias} realizada");
                Enter();
            }
            if(menu == 5)
            {
                Console.Clear();
                Console.WriteLine($"Você tem {listaReservas.Count()} reservas realizadas");
                foreach(Reserva reserva in listaReservas)
                {
                    Console.WriteLine($"O valor da diária é: {reserva.CalculaValorDiaria()} ");
                }
                Enter();
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