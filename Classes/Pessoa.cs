namespace Namespace;
public class Pessoa
{

    private string _cpf;
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf
    {
        get => _cpf; set
        {
            if (value.Length == 11)
            {
                _cpf = value;
            }
            else{
                throw new ArgumentException("Cpf deve conter 11 dígitos!");
            }
        }
    }

    public int getIdade(){
        DateTime now = DateTime.Now;
        int idade = CalcularIdade(this.DataNascimento, now);
        return idade;
        
    }
    static int CalcularIdade(DateTime dataDeNascimento, DateTime dataAtual)
    {
        int idade = dataAtual.Year - dataDeNascimento.Year;
        if (dataAtual.Month < dataDeNascimento.Month || (dataAtual.Month == dataDeNascimento.Month && dataAtual.Day < dataDeNascimento.Day))
        {
            idade--;
        }

        return idade;
    }

}
