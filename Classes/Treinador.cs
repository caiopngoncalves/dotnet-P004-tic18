namespace Namespace;
public class Treinador : Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Cref { get; set; }
}

class Program {
    static List<Treinador> treinadores = new List<Treinador>();

    static void Main() {
        IncluirTreinador("Treinador 1", 30, "12345-CREF");
        IncluirTreinador("Treinador 2", 25, "98765-CREF");

        ListarTreinadores();

        RemoverTreinador("Treinador 1");
    }

    static void IncluirTreinador(string nome, int idade, string cref) {
        if (!treinadores.Any(t => t.Nome == nome)) {
            Treinador novoTreinador = new Treinador { Nome = nome, Idade = idade, Cref = cref};
            treinadores.Add(novoTreinador);
            Console.WriteLine($"{nome} foi incluído como treinador com o CREF: {cref}.");
        }
        else {
            Console.WriteLine($"{nome} ja esta na lista de treindores.");
        }
    }

    static void RemoverTreinador(string nome) {
        Treinador treinador = treinadores.FirstOrDefault(t => t.Nome == nome)!;
        if (treinador != null) {
            treinadores.Remove(treinador);
            Console.WriteLine($"{nome} foi removido como treinador.");
        }
        else {
            Console.WriteLine($"Treinador {nome} nao encontrado.");
        }
    }

    static void ListarTreinadores() {
        Console.WriteLine("Lista de Treinadores: ");
        foreach (var treinador in treinadores) {
            Console.WriteLine($"Nome: {treinador.Nome}, Idade: {treinador.Idade}");
        }
        Console.WriteLine();
    }
}