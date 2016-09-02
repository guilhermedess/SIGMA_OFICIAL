using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USJT.Sigma.Model
{
    public class AtividadeAluno
    {
        public int IdAtividadeAluno { get; set; }
        public int IdAluno { get; set; }
        public int IdAtividade { get; set; }
        public Atividade Atividade { get; set; }
        public AtividadeAluno()
        {
            Atividade = new Atividade();
        }
    }
}
