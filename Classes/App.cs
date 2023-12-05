namespace Namespace;
public class App
{
    private List<Pessoa> pessoas = new List<Pessoa>();
    static List<Treino> treinos = new List<Treino>();
    static List<Exercicio> execicios = new List<Exercicio>();


    private void IncluirCliente() 
    {
    Console.WriteLine("===== Incluir Cliente =====");

    try
    {
        Console.Write("Nome do Cliente: ");
        string nome = Console.ReadLine();

        Console.Write("Data de Nascimento (yyyy-MM-dd): ");

        
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
        {
            throw new Exception("Formato de data inválido. Utilize o formato yyyy-MM-dd.");
        }

        Console.Write("CPF (11 dígitos): ");
        string cpf = Console.ReadLine();

        // Verificar se o CPF já existe na base
        if (pessoas.Any(p => p is Cliente && ((Cliente)p).Cpf == cpf))
        {
            
            throw new Exception($"Ops. O CPF '{cpf}' já existe na base.");
        }

        Console.Write("Altura (em metros): ");
        double altura = double.Parse(Console.ReadLine());

        Console.Write("Peso (em quilogramas): ");
        double peso = double.Parse(Console.ReadLine());

        // Criando um novo objeto Cliente
        Cliente novoCliente = new Cliente
        {
            Nome = nome,
            DataNascimento = dataNascimento,
            Cpf = cpf,
            Altura = altura,
            Peso = peso
        };

        pessoas.Add(novoCliente);

        Console.WriteLine("Cliente adicionado com sucesso!\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao incluir cliente: {ex.Message}\n");
    }
}

    private void RemoverCliente()
    {

    Console.Write("Digite o CPF do cliente que deseja remover: ");
    string cpfRemover = Console.ReadLine();

    // Encontrar o cliente na lista de pessoas pelo CPF
    Cliente clienteRemover = pessoas.OfType<Cliente>().FirstOrDefault(c => c.Cpf == cpfRemover);

    if (clienteRemover != null)
    {
        // Remover o cliente da lista
        pessoas.Remove(clienteRemover);
        Console.WriteLine("Cliente removido com sucesso!\n");
    }
    else
    {
        Console.WriteLine("Cliente não encontrado.\n");
    }
}

private void ListarCliente()
{
    Console.WriteLine("Lista de Clientes:");
    foreach (Pessoa p in pessoas)
    {
        if (p is Cliente)
        {
            Console.WriteLine("Nome: " + p.Nome + " - Data de Nascimento: " + p.DataNascimento + " - Cpf: " + p.Cpf);
        }
    }
}
private void IncluirTreinoEmCliente()
{
    Console.WriteLine("===== Incluir Treino em Cliente =====");

    try
    {
        // Listar os clientes disponíveis
        Console.WriteLine("Lista de Clientes:");
        ListarCliente();

        // Solicitar ao usuário escolher um cliente
        Console.Write("Digite o CPF do cliente: ");
        string cpfCliente = Console.ReadLine();

        // Buscar o cliente na lista de pessoas
        Cliente clienteSelecionado = pessoas.OfType<Cliente>().FirstOrDefault(c => c.Cpf == cpfCliente);

        if (clienteSelecionado == null)
        {
            Console.WriteLine("Cliente não encontrado.\n");
            return;
        }

        // Listar os treinos disponíveis
        Console.WriteLine("Lista de Treinos:");
        ListarTreino()
;
        Console.Write("Digite o tipo do treino existente: ");
        string tipoTreinoExistente = Console.ReadLine();

        
        Treino treinoExistente = treinos.FirstOrDefault(t => t.Tipo == tipoTreinoExistente);

        if (treinoExistente == null)
        {
            Console.WriteLine("Treino não encontrado.\n");
            return;
        }

        // Adicionar o cliente ao treino existente
        treinoExistente.ClientesAvaliacao.Add((clienteSelecionado, 0)); // 0 é uma avaliação padrão

        Console.WriteLine("Cliente adicionado ao treino com sucesso!\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao incluir treino em cliente: {ex.Message}\n");
    }
}
private void RemoverTreinoEmCliente()
{
    Console.WriteLine("===== Remover Treino de Cliente =====");

    try
    {
        // Listar os clientes disponíveis
        Console.WriteLine("Lista de Clientes:");
        ListarCliente();

        // Solicitar ao usuário escolher um cliente
        Console.Write("Digite o CPF do cliente: ");
        string cpfCliente = Console.ReadLine();

        // Buscar o cliente na lista de pessoas
        Cliente clienteSelecionado = pessoas.OfType<Cliente>().FirstOrDefault(c => c.Cpf == cpfCliente);

        if (clienteSelecionado == null)
        {
            Console.WriteLine("Cliente não encontrado.\n");
            return;
        }

        // Listar os treinos disponíveis para remoção do cliente
        Console.WriteLine($"Lista de Treinos do Cliente {clienteSelecionado.Nome}:");
        ListarTreinosDoCliente(clienteSelecionado);

        // Solicitar ao usuário escolher um treino associado ao cliente para remoção
        Console.Write("Digite o tipo do treino a ser removido: ");
        string tipoTreinoRemover = Console.ReadLine();

        // Buscar o treino na lista de treinos
        Treino treinoRemover = treinos.FirstOrDefault(t => t.Tipo == tipoTreinoRemover);

        if (treinoRemover == null)
        {
            Console.WriteLine($"Treino não encontrado.\n");
            return;
        }

        // Remover o cliente do treino
        treinoRemover.ClientesAvaliacao.RemoveAll(c => c.Item1 == clienteSelecionado);

        Console.WriteLine($"Cliente removido do treino com sucesso!\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao remover treino de cliente: {ex.Message}\n");
    }
}

private void ListarTreinosDoCliente(Cliente cliente)
{
    foreach (Treino treino in treinos)
    {
        
        if (treino.ClientesAvaliacao.Any(c => c.Item1 == cliente))
        {
            Console.WriteLine($"Tipo: {treino.Tipo} - Objetivo: {treino.Objetivo}");
        }
    }
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
        // Implementação para incluir um treino
    }

    private void RemoverTreino()
    {
        // Implementação para remover um treino
    }

    private void IncluirExercicioNoTreino()
    {
        // Implementação para incluir um exercício em um treino
    }

    private void RemoverExercicioDoTreino()
    {
        // Implementação para remover um exercício de um treino
    }

    private void IncluirExercicio()
    {
        // Implementação para incluir um exercício
    }

    private void RemoverExercicio()
    {
        // Implementação para remover um exercício
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
        Console.WriteLine("======================");
        Console.WriteLine("1. Incluir Cliente");
        Console.WriteLine("2. Remover Cliente");
        Console.WriteLine("3. Listar Clientes");
        Console.WriteLine("4. Incluir Treino em Cliente");
        Console.WriteLine("5. Remover Treino em Cliente");
        Console.WriteLine("6. Listar Treinos em Cliente");
        Console.WriteLine("7. Voltar");
        Console.Write("Escolha uma opção (1-7): ");

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
                Console.WriteLine("3. Listar Clientes");
                ListarCliente();
                break;
            case "4":
                Console.WriteLine("4. Incluir Treino em Cliente");
                IncluirTreinoEmCliente();
                break;
            case "5":
                Console.WriteLine("5. Remover Treino em Cliente");
                RemoverTreinoEmCliente();
                break;
            case "6":
                Console.WriteLine("6. Listar Treinos em Cliente");
                ListarTreinosDoCliente();
                break;
            case "7":
                Console.WriteLine("7. Voltar");
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
