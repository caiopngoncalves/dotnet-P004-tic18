namespace Namespace;

public class Treino
{
    public string Tipo { get; set; }
    public string Objetivo { get; set; }
    public List<Exercicio> ListaExercicios { get; set; }
    public int DuracaoEstimadaMinutos { get; set; }
    public DateTime DataInicio { get; set; }
    public int VencimentoDias { get; set; }
    public Treinador TreinadorResponsavel { get; set; }
    public List<(Cliente, int)> ClientesAvaliacao { get; set; }

    // Construtor
    public Treino(string tipo, string objetivo, List<Exercicio> listaExercicios, int duracaoEstimadaMinutos,
                  DateTime dataInicio, int vencimentoDias, Treinador treinadorResponsavel,
                  List<(Cliente, int)> clientesAvaliacao)
    {
        Tipo = tipo;
        Objetivo = objetivo;
        ListaExercicios = listaExercicios;
        DuracaoEstimadaMinutos = duracaoEstimadaMinutos;
        DataInicio = dataInicio;
        VencimentoDias = vencimentoDias;
        TreinadorResponsavel = treinadorResponsavel;
        ClientesAvaliacao = clientesAvaliacao;
    }
}
