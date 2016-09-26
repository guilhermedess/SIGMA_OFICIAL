using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USJT.Sigma.Model
{
    public class Aluno
    {
        public int IdAluno { get; set; }
        public Topico IdTopico { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Usuário { get; set; }
        public string Senha { get; set; }
        public double TotalPontosFeitos { get; set; }
        public double ProgressoTotal { get; set; }
        public double ProgressoDistribuicao { get; set; }
        public double ProgressoMedidasDeTendenciaCentral { get; set; }
        public double ProgressoMedidasDeDispersao { get; set; }
        public double ProgressoAmostragemEstimadores { get; set; }
        public double ProgressoDistribuicaoPorAtividade { get; set; }
        public double ProgressoMedidasDeTendenciaPorAtividade { get; set; }
        public double ProgressoMedidasDeDispersaoPorAtividade { get; set; }
        public double ProgressoAmostragemEstimadoresPorAtividade { get; set; }
        public double PontosDistribuicao { get; set; }
        public double PontosMedidasDeTendenciaCentral { get; set; }
        public double PontosMedidasDeDispersao { get; set; }
        public double PontosAmostragemEstimadores { get; set; }
        public double PontosFeitosDistribuicao { get; set; }
        public double PontosFeitosMedidasDeTendenciaCentral { get; set; }
        public double PontosFeitosMedidasDeDispersao { get; set; }
        public double PontosFeitosAmostragemEstimadores { get; set; }
        public double PDIntroducao { get; set; }
        public double PDPontosValores { get; set; }
        public double PDClassesIntervalos { get; set; }
        public double PDRelativaPercentual { get; set; }
        public double PDAcumuladaSimplesAbsoluta { get; set; }
        public double PDAcumuladaRelativaPercentual { get; set; }
        public double PDFreqPontosValores { get; set; }
        public double PDFreqClassesIntervalos { get; set; }
        public double PTIntroducao { get; set; }
        public double PTMediaSimples { get; set; }
        public double PTMediaPonderada { get; set; }
        public double PTModa { get; set; }
        public double PTMediana { get; set; }
        public int topicoSelecionadoAtv { get; set; }
        public double Pontos { get; set; }
    }
}
