namespace Namespace;
public class Cliente : Pessoa
{
    public double Altura { get; set; }
    public double Peso { get; set; }

    public List<IPagamento> Pagamentos = new List<IPagamento>();
    public double getImc(){
        return this.Peso / this.Altura * this.Altura;
    }


private Plano PlanoAtivo;

}
