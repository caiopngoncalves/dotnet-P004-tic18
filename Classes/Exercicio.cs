namespace Namespace;

public class Exercicio
{
    public string GrupoMuscular { get; set; }
    public int Series { get; set; }
    public int Repeticoes { get; set; }
    public int TempoIntervaloSegundos { get; set; }
    private string _codigo;
    public string Codigo
    {
        get => _codigo; set
        {
            if (value.Length == 5)
            {
                _codigo = value;
            }
            else{
                throw new ArgumentException("Codigo deve conter 5 dígitos!");
            }
        }
    }

    // Construtor
    public Exercicio(string grupoMuscular, int series, int repeticoes, int tempoIntervaloSegundos, string codigo)
    {
        GrupoMuscular = grupoMuscular;
        Series = series;
        Repeticoes = repeticoes;
        TempoIntervaloSegundos = tempoIntervaloSegundos;
        Codigo = codigo;
    }
}
