namespace Namespace;
public class App
{
    private List<Pessoa> pessoas = new List<Pessoa>();
    static List<Treino> treinos = new List<Treino>();
    static List<Exercicio> execicios = new List<Exercicio>();


    private void IncluirCliente()
    {
        // Implementação para incluir um cliente
    }

    private void RemoverCliente()
    {
        // Implementação para remover um cliente
    }

    private void IncluirTreinador()
    {
        // Implementação para incluir um treinador
    }

    private void RemoverTreinador()
    {
        // Implementação para remover um treinador
    }

    private void IncluirTreino()
    {
        Console.WriteLine($"CREF do treinador responsavel: ");
        string cref = Console.ReadLine();
        int indexTreinador = -1;

        bool check = false;
        for(int i = 0; i < pessoas.Count(); i++){
            indexTreinador++;
            if(pessoas[i] is Treinador){
                if(String.Equals(pessoas[i].Cref, cref)){
                    check = true;
                }
            }
        } 

        if(!check){
            Console.WriteLine("CREF nao encontrado");
            return;
        }

        Console.WriteLine($"Tipo: ");
        string tipo = Console.ReadLine();
        
        Console.WriteLine($"Objetivo: ");
        string objetivo = Console.ReadLine();
        
        Console.WriteLine($"Duracao estimada em minutos: ");
        int duracaoEstimadaMinutos = int.Parse(Console.ReadLine());
        
        Console.WriteLine($"Data de inicio: ");
        DateTime dataInicio = DateTime.Parse(Console.ReadLine());
        
        Console.WriteLine($"Dias ate vencimento: ");
        int vencimentoDias = int.Parse(Console.ReadLine());
        
        check = false;
        Random rnd = new Random();
        string codigo = "";
        do{
            check = true;

            for(int i = 0; i < 5; i++){
                codigo += rnd.Next(0, 10).ToString();
            }

            for(int i = 0; i < App.treinos.Count(); i++){
                if(String.Equals(App.treinos[i].Codigo, codigo)){
                    check = false;
                    codigo = "";
                }
            }

        } while(!check);

        List<Exercicio> listaExercicio = new List<Exercicio>();
        List<(Cliente, int)> clientesAvaliacao = new List<(Cliente, int)>();

        Treino treino = new Treino(tipo, objetivo, listaExercicio, duracaoEstimadaMinutos, dataInicio, vencimentoDias, pessoas[indexTreinador], clientesAvaliacao, codigo);
        App.treinos.Add(treino);
    }

    private void RemoverTreino()
    {
        // Implementação para remover um treino
    }

    private void IncluirExercicioNoTreino()
    {
        Console.WriteLine("Codigo do treino: ");
        string codigoTreino = Console.ReadLine();

        bool check = false;
        int indexTreino = 0;

        //Procurando se o codigo de treino existe e guardando o index
        for(int i = 0; i < App.treinos.Count(); i++){
            if(String.Equals(App.treinos[i].Codigo, codigoTreino)){
                check = true;
                indexTreino = i;
                break;
            }
        }

        if(!check){
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        if(App.treinos[indexTreino].ListaExercicios.Count() >= 10){
            Console.WriteLine($"O treino especificado ja atingiu o numero maximo de exercicios");
            return;
        }

        Console.WriteLine("Codigo do exercicio: ");
        string codigoExercicio = Console.ReadLine();
        check = false;
        int indexExercicio = 0;

        //Procurando se o codigo de exercicio existe e guardando o index
        for(int i = 0; i < App.execicios.Count(); i++){
            if(String.Equals(App.execicios[i].Codigo, codigoExercicio)){
                check = true;
                indexExercicio = i;
                break;
            }
        }

        if(!check){
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        App.treinos[indexTreino].ListaExercicios.Add(App.execicios[indexExercicio]);
        Console.WriteLine($"Exercicio incluido no treino com sucesso");
        
    }

    private void RemoverExercicioDoTreino()
    {
        Console.WriteLine("Codigo do treino: ");
        string codigoTreino = Console.ReadLine();

        bool check = false;
        int indexTreino = 0;

        //Procurando se o codigo de treino existe e guardando o index
        for(int i = 0; i < App.treinos.Count(); i++){
            if(String.Equals(App.treinos[i].Codigo, codigoTreino)){
                check = true;
                indexTreino = i;
                break;
            }
        }

        if(!check){
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        Console.WriteLine("Codigo do exercicio: ");
        string codigoExercicio = Console.ReadLine();
        check = false;
        int indexExercicio = 0;

        //Procurando se o codigo de exercicio existe e guardando o index
        for(int i = 0; i < App.execicios.Count(); i++){
            if(String.Equals(App.execicios[i].Codigo, codigoExercicio)){
                check = true;
                indexExercicio = i;
                break;
            }
        }

        if(!check){
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        App.treinos[indexTreino].ListaExercicios.RemoveAt(indexExercicio);
        Console.WriteLine($"Exercicio removido do treino com sucesso");
    }

    private void IncluirExercicio()
    {
        Console.WriteLine($"Grupo Muscular: ");
        string grupoMuscular = Console.ReadLine();

        Console.WriteLine($"Numero de series: ");
        int series = int.Parse(Console.ReadLine());

        Console.WriteLine($"Numero de repeticoes: ");
        int repeticoes = int.Parse(Console.ReadLine());

        Console.WriteLine($"Intervalo (segundos) entre series: ");
        int tempoIntervaloSegundos = int.Parse(Console.ReadLine());

        bool check = false;
        Random rnd = new Random();
        string codigo = "";
        do{
            check = true;

            for(int i = 0; i < 5; i++){
                codigo += rnd.Next(0, 10).ToString();
            }

            for(int i = 0; i < App.execicios.Count(); i++){
                if(String.Equals(App.execicios[i].Codigo, codigo)){
                    check = false;
                    codigo = "";
                }
            }

        } while(!check);

        Exercicio exercicio = new Exercicio(grupoMuscular, series, repeticoes, tempoIntervaloSegundos, codigo);
        App.execicios.Add(exercicio);

        Console.WriteLine($"Exercicio cadastrado com sucesso.");
    }

    private void RemoverExercicio()
    {
        Console.WriteLine($"Codigo: ");
        string codigo = Console.ReadLine();

        bool check = false;
        int index = 0;

        //Procurando se o codigo existe e guardando o index
        for(int i = 0; i < App.execicios.Count(); i++){
            if(String.Equals(App.execicios[i].Codigo, codigo)){
                check = true;
                index = i;
                break;
            }
        }

        if(!check){
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        //Removendo o exercicio em todos os treinos em que ele faz parte
        for(int i = 0; i < App.treinos.Count(); i++){
            for(int j = 0; j < App.treinos[i].ListaExercicios.Count(); j++){
                if(String.Equals(codigo, App.treinos[i].ListaExercicios[j].Codigo)){
                    App.treinos[i].ListaExercicios.RemoveAt(j);
                }
            }
        }

        App.execicios.RemoveAt(index);
        Console.WriteLine($"Exercicio removido com sucesso.");
    }

    public void ListarExercicios()
    {
        var listaOrdenada = App.execicios.OrderBy(x => x.GrupoMuscular).ToList();

        Console.WriteLine(String.Join("\n", listaOrdenada.Select(x => $"{x.Codigo} - {x.GrupoMuscular} - {x.Repeticoes} - {x.Series} - {x.TempoIntervaloSegundos}")));
        
    }

    public void RelatorioTreinadoresPorIdade()
    {
        System.Console.WriteLine("Digite um valor mínimo de idade:");
        int min = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Digite um valor máximo de idade:");
        int max = int.Parse(Console.ReadLine()!);

        foreach (Pessoa p in pessoas)
        {
            if (p is Treinador)
            {
                if (p.getIdade() >= min && p.getIdade() <= max)
                {
                    System.Console.WriteLine("Nome: " + p.Nome + " - Data de Nascimento: " + p.DataNascimento + " - Cpf: " + p.Cpf);
                }
            }
        };
    }

    private void RelatorioClientesPorIdade()
    {
        System.Console.WriteLine("Digite um valor mínimo de idade:");
        int min = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Digite um valor máximo de idade:");
        int max = int.Parse(Console.ReadLine()!);

        foreach (Pessoa p in pessoas)
        {
            if (p is Cliente)
            {
                if (p.getIdade() > min && p.getIdade() < max)
                {
                    System.Console.WriteLine("Nome: " + p.Nome + " - Data de Nascimento: " + p.DataNascimento + " - Cpf: " + p.Cpf);
                }
            }
        };
    }

    private void RelatorioClientesPorIMC()
    {
        System.Console.WriteLine("Digite um valor base para o imc");
        double min = double.Parse(Console.ReadLine()!);

        foreach (Pessoa p in pessoas)
        {
            if (p is Cliente)
            {
                Cliente c = (Cliente)p;
                if (c.getImc() >= min)
                {
                    System.Console.WriteLine("Nome: " + p.Nome + " - Data de Nascimento: " + p.DataNascimento + " - Cpf: " + p.Cpf);
                }
            }
        };
    }

    private void RelatorioClientesOrdemAlfabetica()
    {
        this.pessoas = this.pessoas.OrderBy(c => c.Nome).ToList();
        foreach (Pessoa p in pessoas)
        {
            if (p is Cliente)
            {

                System.Console.WriteLine("Nome: " + p.Nome + " - Data de Nascimento: " + p.DataNascimento + " - Cpf: " + p.Cpf);

            }
        };
    }

    private void RelatorioClientesMaisVelhoParaMaisNovo()
    {
        this.pessoas = this.pessoas.OrderBy(c => c.getIdade()).ToList();
        foreach (Pessoa p in pessoas)
        {
            if (p is Cliente)
            {

                System.Console.WriteLine("Nome: " + p.Nome + " - Data de Nascimento: " + p.DataNascimento + " - Cpf: " + p.Cpf);

            }
        };
    }

    private void RelatorioAniversariantesDoMes()
    {
        System.Console.WriteLine("Digite um mes de 1 ate 12:");
        int mes = int.Parse(Console.ReadLine()!);
        foreach (Pessoa p in pessoas)
        {
            if (p.DataNascimento.Month == mes)
            {

                System.Console.WriteLine("Nome: " + p.Nome + " - Data de Nascimento: " + p.DataNascimento + " - Cpf: " + p.Cpf);

            }
        };
    }

    private void RelatorioTreinosPorDiasAteVencimento()
    {
        // Implementação do relatório
    }

    private void RelatorioTreinadoresPorMediaNotas()
    {
        // Implementação do relatório
    }

    private void RelatorioTreinosPorObjetivo()
    {
        // Implementação do relatório
    }

    private void RelatorioTop10Exercicios()
    {
        // Implementação do relatório
    }

    private void MenuClientes()
    {
        bool voltar = false;

        do
        {
            Console.WriteLine("===== Menu de Clientes =====");
            Console.WriteLine("1. Incluir Cliente");
            Console.WriteLine("2. Remover Cliente");
            Console.WriteLine("3. Voltar");
            Console.Write("Escolha uma opção (1-3): ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("1. Incluir Cliente");
                    IncluirCliente();
                    break;
                case "2":
                    Console.WriteLine("2. Remover Cliente");
                    RemoverCliente();
                    break;
                case "3":
                    Console.WriteLine("3. Voltar");
                    voltar = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (!voltar);
    }

    private void MenuTreinadores()
    {
        bool voltar = false;

        do
        {
            Console.WriteLine("===== Menu de Treinadores =====");
            Console.WriteLine("1. Incluir Treinador");
            Console.WriteLine("2. Remover Treinador");
            Console.WriteLine("3. Voltar");
            Console.Write("Escolha uma opção (1-3): ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("1. Incluir Treinador");
                    IncluirTreinador();
                    break;
                case "2":
                    Console.WriteLine("2. Remover Treinador");
                    RemoverTreinador();
                    break;
                case "3":
                    Console.WriteLine("3. Voltar");
                    voltar = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (!voltar);
    }

    private void MenuTreinos()
    {
        bool voltar = false;

        do
        {
            Console.WriteLine("===== Menu de Treinos =====");
            Console.WriteLine("1. Incluir Treino");
            Console.WriteLine("2. Remover Treino");
            Console.WriteLine("3. Incluir Exercício no Treino");
            Console.WriteLine("4. Remover Exercício do Treino");
            Console.WriteLine("5. Voltar");
            Console.Write("Escolha uma opção (1-5): ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("1. Incluir Treino");
                    IncluirTreino();
                    break;
                case "2":
                    Console.WriteLine("2. Remover Treino");
                    RemoverTreino();
                    break;
                case "3":
                    Console.WriteLine("3. Incluir Exercício no Treino");
                    IncluirExercicioNoTreino();
                    break;
                case "4":
                    Console.WriteLine("4. Remover Exercício do Treino");
                    RemoverExercicioDoTreino();
                    break;
                case "5":
                    Console.WriteLine("5. Voltar");
                    voltar = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (!voltar);
    }

    private void MenuExercicios()
    {
        bool voltar = false;

        do
        {
            Console.WriteLine("===== Menu de Exercícios =====");
            Console.WriteLine("1. Incluir Exercício");
            Console.WriteLine("2. Remover Exercício");
            Console.WriteLine("3. Voltar");
            Console.Write("Escolha uma opção (1-3): ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("1. Incluir Exercício");
                    IncluirExercicio();
                    break;
                case "2":
                    Console.WriteLine("2. Remover Exercício");
                    RemoverExercicio();
                    break;
                case "3":
                    Console.WriteLine("3. Voltar");
                    voltar = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (!voltar);
    }

    public void MenuRelatorios()
    {
        bool voltar = false;

        do
        {
            Console.WriteLine("===== Menu de Relatórios =====");
            Console.WriteLine("1. Treinadores com idade entre dois valores");
            Console.WriteLine("2. Clientes com idade entre dois valores");
            Console.WriteLine("3. Clientes com IMC maior que um valor informado, em ordem crescente");
            Console.WriteLine("4. Clientes em ordem alfabética");
            Console.WriteLine("5. Clientes do mais velho para mais novo");
            Console.WriteLine("6. Treinadores e clientes aniversariantes do mês informado");
            Console.WriteLine("7. Treinos em ordem crescente pela quantidade de dias até o vencimento");
            Console.WriteLine("8. Treinadores em ordem decrescente da média de notas dos seus treinos");
            Console.WriteLine("9. Treinos cujo objetivo contenham determinada palavra");
            Console.WriteLine("10. Top 10 exercícios mais utilizados nos treinos");
            Console.WriteLine("11. Voltar");
            Console.Write("Escolha uma opção (1-11): ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("1. Treinadores com idade entre dois valores");
                    RelatorioTreinadoresPorIdade();
                    break;
                case "2":
                    Console.WriteLine("2. Clientes com idade entre dois valores");
                    RelatorioClientesPorIdade();
                    break;
                case "3":
                    Console.WriteLine("3. Clientes com IMC maior que um valor informado, em ordem crescente");
                    RelatorioClientesPorIMC();
                    break;
                case "4":
                    Console.WriteLine("4. Clientes em ordem alfabética");
                    RelatorioClientesOrdemAlfabetica();
                    break;
                case "5":
                    Console.WriteLine("5. Clientes do mais velho para mais novo");
                    RelatorioClientesMaisVelhoParaMaisNovo();
                    break;
                case "6":
                    Console.WriteLine("6. Treinadores e clientes aniversariantes do mês informado");
                    RelatorioAniversariantesDoMes();
                    break;
                case "7":
                    Console.WriteLine("7. Treinos em ordem crescente pela quantidade de dias até o vencimento");
                    RelatorioTreinosPorDiasAteVencimento();
                    break;
                case "8":
                    Console.WriteLine("8. Treinadores em ordem decrescente da média de notas dos seus treinos");
                    RelatorioTreinadoresPorMediaNotas();
                    break;
                case "9":
                    Console.WriteLine("9. Treinos cujo objetivo contenham determinada palavra");
                    RelatorioTreinosPorObjetivo();
                    break;
                case "10":
                    Console.WriteLine("10. Top 10 exercícios mais utilizados nos treinos");
                    RelatorioTop10Exercicios();
                    break;
                case "11":
                    Console.WriteLine("11. Voltar");
                    voltar = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (!voltar);
    }

    public void Executar()
    {

        bool sair = false;

        do
        {
            Console.WriteLine("===== Menu Inicial =====");
            Console.WriteLine("1. Gerenciar Clientes");
            Console.WriteLine("2. Gerenciar Treinadores");
            Console.WriteLine("3. Gerenciar Treinos");
            Console.WriteLine("4. Gerenciar Exercícios");
            Console.WriteLine("5. Relatórios");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção (1-6): ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("1. Gerenciar Clientes");
                    MenuClientes();
                    break;
                case "2":
                    Console.WriteLine("2. Gerenciar Treinadores");
                    MenuTreinadores();
                    break;
                case "3":
                    Console.WriteLine("3. Gerenciar Treinos");
                    MenuTreinos();
                    break;
                case "4":
                    Console.WriteLine("4. Gerenciar Exercícios");
                    MenuExercicios();
                    break;
                case "5":
                    Console.WriteLine("5. Relatórios");
                    MenuRelatorios();
                    break;
                case "6":
                    Console.WriteLine("6. Sair");
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (!sair);
    }
}
