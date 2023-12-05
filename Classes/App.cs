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

            if (pessoas.Any(p => p is Cliente && ((Cliente)p).Cpf == cpf))
            {

                throw new Exception($"Ops. O CPF '{cpf}' já existe na base.");
            }

            Console.Write("Altura (em metros): ");
            double altura = double.Parse(Console.ReadLine());

            Console.Write("Peso (em quilogramas): ");
            double peso = double.Parse(Console.ReadLine());

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

        Cliente clienteRemover = pessoas.OfType<Cliente>().FirstOrDefault(c => c.Cpf == cpfRemover);

        if (clienteRemover != null)
        {
            pessoas.Remove(clienteRemover);
            Console.WriteLine("Cliente removido com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.\n");
        }
    }

    private void IncluirTreinador()
    {
        Treinador novoTreinador = new Treinador();

        Console.Write("Nome do treinador: ");
        novoTreinador.Nome = Console.ReadLine();

        Console.Write("Data de nascimento (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
        {
            novoTreinador.DataNascimento = dataNascimento;
        }
        else
        {
            Console.WriteLine("Data de nascimento inválida.");
            return;
        }

        Console.Write("CPF (11 dígitos): ");
        novoTreinador.Cpf = Console.ReadLine();

        Console.Write("CREF: ");
        novoTreinador.Cref = Console.ReadLine();

        if (!pessoas.Contains(novoTreinador))
        {
            pessoas.Add(novoTreinador);
            Console.WriteLine("Treinador incluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Este treinador já existe na lista.");
        }
    }

    private void RemoverTreinador()
    {
        Console.Write("CPF do treinador a ser removido: ");
        string cpf = Console.ReadLine();

        Treinador treinadorParaRemover = pessoas.OfType<Treinador>().FirstOrDefault(t => t.Cpf == cpf);

        if (treinadorParaRemover != null)
        {
            pessoas.Remove(treinadorParaRemover);
            Console.WriteLine("Treinador removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Treinador não encontrado na lista.");
        }
    }

    private void IncluirTreino()
    {
        Console.Write("Tipo de treino: ");
        string tipo = Console.ReadLine();

        Console.Write("Objetivo do treino: ");
        string objetivo = Console.ReadLine();

        Console.WriteLine("Exercícios disponíveis:");
        ListarExercicio();

        List<Exercicio> listaExercicios = new List<Exercicio>();
        Console.WriteLine("Adicione exercícios ao treino (Digite 'sair' para finalizar):");
        while (true)
        {
            Console.Write("Código do exercício (ou 'sair' para finalizar): ");
            string codigoExercicio = Console.ReadLine();

            if (codigoExercicio.ToLower() == "sair")
                break;

            Exercicio exercicio = execicios.FirstOrDefault(e => e.Codigo == codigoExercicio);

            if (exercicio == null)
            {
                Console.WriteLine("Exercício não encontrado. Por favor, escolha um código válido.");
                continue;
            }

            listaExercicios.Add(exercicio);
        }

        Console.Write("Duração estimada em minutos: ");
        if (!int.TryParse(Console.ReadLine(), out int duracaoEstimadaMinutos))
        {
            Console.WriteLine("Duração inválida.");
            return;
        }

        Console.Write("Data de início (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataInicio))
        {
            Console.WriteLine("Data inválida.");
            return;
        }

        Console.Write("Vencimento em dias: ");
        if (!int.TryParse(Console.ReadLine(), out int vencimentoDias))
        {
            Console.WriteLine("Número de dias inválido.");
            return;
        }

        Console.Write("CPF do treinador responsável: ");
        string cpfTreinador = Console.ReadLine();
        Treinador treinadorResponsavel = pessoas.OfType<Treinador>().FirstOrDefault(t => t.Cpf == cpfTreinador);

        if (treinadorResponsavel == null)
        {
            Console.WriteLine("Treinador não encontrado.");
            return;
        }

        Console.Write("Código do treino (5 dígitos): ");
        string codigo = Console.ReadLine();

        Treino novoTreino = new Treino(tipo, objetivo, listaExercicios, duracaoEstimadaMinutos,
                                       dataInicio, vencimentoDias, treinadorResponsavel, codigo);

        treinos.Add(novoTreino);
        Console.WriteLine("Treino incluído com sucesso!");
    }

    private void RemoverTreino()
    {
        Console.Write("Código do treino a ser removido: ");
        string codigoTreino = Console.ReadLine();

        Treino treinoParaRemover = treinos.FirstOrDefault(t => t.Codigo == codigoTreino);

        if (treinoParaRemover != null)
        {
            treinos.Remove(treinoParaRemover);
            Console.WriteLine("Treino removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Treino não encontrado na lista.");
        }
    }


    private void ListarTreino()
    {
        if (treinos.Count == 0)
        {
            Console.WriteLine("Não há treinos cadastrados.");
            return;
        }

        Console.WriteLine("Lista de Treinos:");

        foreach (var treino in treinos)
        {
            Console.WriteLine($"Código: {treino.Codigo}");
            Console.WriteLine($"Tipo: {treino.Tipo}");
            Console.WriteLine($"Objetivo: {treino.Objetivo}");
            Console.WriteLine($"Duração Estimada: {treino.DuracaoEstimadaMinutos} minutos");
            Console.WriteLine($"Data de Início: {treino.DataInicio:yyyy-MM-dd}");
            Console.WriteLine($"Vencimento em: {treino.VencimentoDias} dias");
            Console.WriteLine($"Treinador Responsável: {treino.TreinadorResponsavel.Nome}");

            Console.WriteLine("Exercícios:");
            foreach (var exercicio in treino.ListaExercicios)
            {
                Console.WriteLine($"- {exercicio.GrupoMuscular}");
            }

            Console.WriteLine("Clientes para Avaliação:");
            foreach (var (cliente, nota) in treino.ClientesAvaliacao)
            {
                Console.WriteLine($"- Cliente: {cliente.Nome}, Nota: {nota}");
            }

            Console.WriteLine("-----");
        }
    }

    private void IncluirExercicioNoTreino()
    {
        Console.WriteLine("Codigo do treino: ");
        string codigoTreino = Console.ReadLine();
        if (codigoTreino.Length != 5 || !int.TryParse(codigoTreino, out _))
        {
            Console.WriteLine($"Erro: o codigo precisa ser 5 caracteres numericos");
            return;
        }

        bool check = false;
        int indexTreino = 0;
        for (int i = 0; i < treinos.Count(); i++)
        {
            if (String.Equals(treinos[i].Codigo, codigoTreino))
            {
                check = true;
                indexTreino = i;
                break;
            }
        }

        if (!check)
        {
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        if (treinos[indexTreino].ListaExercicios.Count() >= 10)
        {
            Console.WriteLine($"O treino especificado ja atingiu o numero maximo de exercicios");
            return;
        }


        //Puxando codigo do treino e vendo se a entrada e valida
        Console.WriteLine("Codigo do exercicio: ");
        string codigoExercicio = Console.ReadLine();
        if (codigoExercicio.Length != 5 || !int.TryParse(codigoExercicio, out _))
        {
            Console.WriteLine($"Erro: o codigo precisa ser 5 caracteres numericos");
            return;
        }

        check = false;
        int indexExercicio = 0;
        for (int i = 0; i < execicios.Count(); i++)
        {
            if (String.Equals(App.execicios[i].Codigo, codigoExercicio))
            {
                check = true;
                indexExercicio = i;
                break;
            }
        }

        if (!check)
        {
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
        if (codigoTreino.Length != 5 || !int.TryParse(codigoTreino, out _))
        {
            Console.WriteLine($"Erro: o codigo precisa ser 5 caracteres numericos");
            return;
        }

        bool check = false;
        int indexTreino = 0;
        for (int i = 0; i < App.treinos.Count(); i++)
        {
            if (String.Equals(App.treinos[i].Codigo, codigoTreino))
            {
                check = true;
                indexTreino = i;
                break;
            }
        }
        if (!check)
        {
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        Console.WriteLine("Codigo do exercicio: ");
        string codigoExercicio = Console.ReadLine();
        if (codigoExercicio.Length != 5 || !int.TryParse(codigoExercicio, out _))
        {
            Console.WriteLine($"Erro: o codigo precisa ser 5 caracteres numericos");
            return;
        }

        check = false;
        int indexExercicio = 0;
        for (int i = 0; i < App.execicios.Count(); i++)
        {
            if (String.Equals(App.execicios[i].Codigo, codigoExercicio))
            {
                check = true;
                indexExercicio = i;
                break;
            }
        }
        if (!check)
        {
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        App.treinos[indexTreino].ListaExercicios.RemoveAt(indexExercicio);
        Console.WriteLine($"Exercicio removido do treino com sucesso");
    }

    private void ListarExercicioNoTreino()
    {
        Console.WriteLine("Codigo do treino: ");
        string codigoTreino = Console.ReadLine();
        if (codigoTreino.Length != 5 || !int.TryParse(codigoTreino, out _))
        {
            Console.WriteLine($"Erro: o codigo precisa ser 5 caracteres numericos");
            return;
        }
        bool check = false;
        int indexTreino = 0;
        for (int i = 0; i < App.treinos.Count(); i++)
        {
            if (String.Equals(App.treinos[i].Codigo, codigoTreino))
            {
                check = true;
                indexTreino = i;
                break;
            }
        }
        if (!check)
        {
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        var listaOrdenada = App.treinos[indexTreino].ListaExercicios.OrderBy(x => x.GrupoMuscular).ToList();
        Console.WriteLine(String.Join("\n", listaOrdenada.Select(x => $"{x.Codigo} - {x.GrupoMuscular} - {x.Repeticoes} - {x.Series} - {x.TempoIntervaloSegundos}")));
    }



    private void RelacionarClienteTreino()
    {
        if (treinos.Count == 0)
        {
            Console.WriteLine("Não há treinos cadastrados.");
            return;
        }

        if (pessoas.OfType<Cliente>().Count() == 0)
        {
            Console.WriteLine("Não há clientes cadastrados.");
            return;
        }

        Console.WriteLine("Lista de Treinos:");
        foreach (var treino in treinos)
        {
            Console.WriteLine($"Código: {treino.Codigo} - Tipo: {treino.Tipo}");
            Console.WriteLine("-----");
        }

        Console.Write("Digite o código do treino: ");
        string codigoTreino = Console.ReadLine();

        Treino treinoRelacionarCliente = treinos.FirstOrDefault(t => t.Codigo == codigoTreino);

        if (treinoRelacionarCliente == null)
        {
            Console.WriteLine("Treino não encontrado na lista.");
            return;
        }

        Console.WriteLine("Lista de Clientes:");
        foreach (var cliente in pessoas.OfType<Cliente>())
        {
            Console.WriteLine($"CPF: {cliente.Cpf}, Nome: {cliente.Nome}");
            Console.WriteLine("-----");
        }

        Console.Write("Digite o CPF do cliente: ");
        string cpfCliente = Console.ReadLine();

        Cliente clienteRelacionar = pessoas.OfType<Cliente>().FirstOrDefault(c => c.Cpf == cpfCliente);

        if (clienteRelacionar == null)
        {
            Console.WriteLine("Cliente não encontrado na lista.");
            return;
        }

        if (treinoRelacionarCliente.ClientesAvaliacao.Count(c => c.Item1 == clienteRelacionar) >= 2)
        {
            Console.WriteLine("Este cliente já está associado a 2 treinos. Não é possível adicionar mais.");
            return;
        }
        Console.Write("Data de início do treino (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataInicio))
        {
            Console.WriteLine("Data inválida.");
            return;
        }

        Console.Write("Vencimento do treino em dias: ");
        if (!int.TryParse(Console.ReadLine(), out int vencimentoDias))
        {
            Console.WriteLine("Número de dias inválido.");
            return;
        }

        Console.Write("Avaliação do cliente (0 a 10): ");
        if (!int.TryParse(Console.ReadLine(), out int avaliacao))
        {
            Console.WriteLine("Avaliação inválida.");
            return;
        }

        treinoRelacionarCliente.ClientesAvaliacao.Add((clienteRelacionar, avaliacao));
        Console.WriteLine("Cliente relacionado ao treino com sucesso!");
    }

    private void IncluirExercicio()
    {
        Console.WriteLine($"Grupo Muscular: ");
        string grupoMuscular = Console.ReadLine();
        if (grupoMuscular == "")
        {
            Console.WriteLine("Erro: Nao e permitida entrada vazia de dados");
            return;
        }

        int series = 0;
        int repeticoes = 0;
        int tempoIntervaloSegundos = 0;

        try
        {
            Console.WriteLine($"Numero de series: ");
            series = int.Parse(Console.ReadLine());

            Console.WriteLine($"Numero de repeticoes: ");
            repeticoes = int.Parse(Console.ReadLine());

            Console.WriteLine($"Intervalo (segundos) entre series: ");
            tempoIntervaloSegundos = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine($"Erro: entrada de numero invalida");
            return;
        }

        if (series <= 0 || repeticoes <= 0 || tempoIntervaloSegundos <= 0)
        {
            Console.WriteLine($"Erro: Nao sao permitidos numeros nulos ou negativos como resposta");
            return;
        }

        bool check = false;
        Random rnd = new Random();
        string codigo = "";
        do
        {
            check = true;

            for (int i = 0; i < 5; i++)
            {
                codigo += rnd.Next(0, 10).ToString();
            }

            for (int i = 0; i < App.execicios.Count(); i++)
            {
                if (String.Equals(App.execicios[i].Codigo, codigo))
                {
                    check = false;
                    codigo = "";
                }
            }

        } while (!check);

        Exercicio exercicio = new Exercicio(grupoMuscular, series, repeticoes, tempoIntervaloSegundos, codigo);
        execicios.Add(exercicio);

        Console.WriteLine($"Exercicio cadastrado com sucesso.");
    }

    private void RemoverExercicio()
    {
        Console.WriteLine($"Codigo: ");
        string codigo = Console.ReadLine();
        if (codigo.Length != 5 || !int.TryParse(codigo, out _))
        {
            Console.WriteLine($"Erro: o codigo precisa ser 5 caracteres numericos");
            return;
        }

        bool check = false;
        int index = 0;
        for (int i = 0; i < execicios.Count(); i++)
        {
            if (String.Equals(execicios[i].Codigo, codigo))
            {
                check = true;
                index = i;
                break;
            }
        }
        if (!check)
        {
            Console.WriteLine($"Codigo nao encontrado");
            return;
        }

        for (int i = 0; i < treinos.Count(); i++)
        {
            for (int j = 0; j < treinos[i].ListaExercicios.Count(); j++)
            {
                if (String.Equals(codigo, treinos[i].ListaExercicios[j].Codigo))
                {
                    treinos[i].ListaExercicios.RemoveAt(j);
                }
            }
        }

        execicios.RemoveAt(index);
        Console.WriteLine($"Exercicio removido com sucesso.");
    }

    private void ListarExercicio()
    {
        foreach (var exercicio in execicios)
        {
            Console.WriteLine($"Código: {exercicio.Codigo}, Nome: {exercicio.GrupoMuscular}");
        }
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
        Console.Write("Digite o número de dias limite para o vencimento: ");
        if (!int.TryParse(Console.ReadLine(), out int diasLimite))
        {
            Console.WriteLine("Número inválido de dias.");
            return;
        }

        var treinosFiltrados = treinos
            .Where(t => (t.DataInicio.AddDays(t.VencimentoDias) - DateTime.Now).Days <= diasLimite)
            .OrderBy(t => (t.DataInicio.AddDays(t.VencimentoDias) - DateTime.Now).Days);

        Console.WriteLine($"Relatório de Treinos com Vencimento em até {diasLimite} dias:");

        foreach (var treino in treinosFiltrados)
        {
            int diasAteVencimento = (treino.DataInicio.AddDays(treino.VencimentoDias) - DateTime.Now).Days;

            Console.WriteLine($"Código: {treino.Codigo}");
            Console.WriteLine($"Tipo: {treino.Tipo}");
            Console.WriteLine($"Data de Início: {treino.DataInicio:yyyy-MM-dd}");
            Console.WriteLine($"Vencimento em: {diasAteVencimento} dias");
            Console.WriteLine("-----");
        }

        if (!treinosFiltrados.Any())
        {
            Console.WriteLine("Nenhum treino encontrado com vencimento dentro do prazo especificado.");
        }
    }

    private void RelatorioTreinadoresPorMediaNotas()
    {
      var treinadores = pessoas.OfType<Treinador>();

        Console.WriteLine("Relatório de Treinadores Ordenados por Média de Notas dos Treinos:");

        foreach (var treinador in treinadores)
        {
            var treinosDoTreinador = treinos.Where(treino => treino.TreinadorResponsavel == treinador && treino.ClientesAvaliacao.Any());

            if (treinosDoTreinador.Any())
            {
                var mediaNotasTreinos = treinosDoTreinador.Average(treino => treino.ClientesAvaliacao.Average(avaliacao => avaliacao.Item2));

                Console.WriteLine($"Nome: {treinador.Nome}");
                Console.WriteLine($"Média de Notas dos Treinos: {mediaNotasTreinos}");
                Console.WriteLine("-----");
            }
        }

        var treinadoresSemTreinos = treinadores.Where(treinador => !treinos.Any(treino => treino.TreinadorResponsavel == treinador));

        foreach (var treinadorSemTreinos in treinadoresSemTreinos)
        {
            Console.WriteLine($"Nome: {treinadorSemTreinos.Nome}");
            Console.WriteLine($"Média de Notas dos Treinos: Nenhum treino encontrado");
            Console.WriteLine("-----");
        }

        if (!treinadores.Any())
        {
            Console.WriteLine("Nenhum treinador encontrado.");
        }
    }

    private void RelatorioTreinosPorObjetivo()
    {
        Console.Write("Digite a palavra-chave do objetivo: ");
        string palavraChave = Console.ReadLine();

        var treinosComObjetivo = treinos
            .Where(treino => treino.Objetivo.Contains(palavraChave, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine($"Relatório de Treinos com Objetivo contendo '{palavraChave}':");
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
            Console.WriteLine("3. Listar Treinos");
            Console.WriteLine("4. Incluir Exercício no Treino");
            Console.WriteLine("5. Remover Exercício do Treino");
            Console.WriteLine("6. Listar Exercícios em um Treino");
            Console.WriteLine("7. Incluir cliente em um treino");
            Console.WriteLine("8. Voltar");
            Console.Write("Escolha uma opção (1-9):");

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
                    Console.WriteLine("3. Listar Treinos");
                    ListarTreino();
                    break;
                case "4":
                    Console.WriteLine("4. Incluir Exercício no Treino");
                    IncluirExercicioNoTreino();
                    break;
                case "5":
                    Console.WriteLine("5. Remover Exercício do Treino");
                    RemoverExercicioDoTreino();
                    break;
                case "6":
                    Console.WriteLine("6. Listar Exercício em um Treino");
                    ListarExercicioNoTreino();
                    break;
                case "7":
                    Console.WriteLine("7. Incluir cliente em um treino");
                    RelacionarClienteTreino();
                    break;
                case "8":
                    Console.WriteLine("8. Voltar");
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
            Console.WriteLine("3. Listar Exercícios");
            Console.WriteLine("4. Voltar");
            Console.Write("Escolha uma opção (1-4): ");

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
                    Console.WriteLine("3. Listar Exercícios");
                    ListarExercicio();
                    break;
                case "4":
                    Console.WriteLine("4. Voltar");
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
