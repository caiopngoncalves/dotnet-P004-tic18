namespace Namespace;

public class Exercicio
{
    public string GrupoMuscular { get; set; }
    public int Series { get; set; }
    public int Repeticoes { get; set; }
    public int TempoIntervaloSegundos { get; set; }

    // Construtor
    public Exercicio(string grupoMuscular, int series, int repeticoes, int tempoIntervaloSegundos)
    {
        GrupoMuscular = grupoMuscular;
        Series = series;
        Repeticoes = repeticoes;
        TempoIntervaloSegundos = tempoIntervaloSegundos;
    }
}
