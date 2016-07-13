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
        public double ProgressoTotal { get; set; }
        public double ProgressoDistribuicao { get; set; }
        public double ProgressoMedidasDeTendenciaCentral { get; set; }
        public double ProgressoMedidasDeDispersao { get; set; }
        public double ProgressoAmostragemEstimadores { get; set; }
    }
}
