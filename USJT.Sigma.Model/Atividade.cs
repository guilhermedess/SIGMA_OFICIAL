using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USJT.Sigma.Model
{
    public class Atividade
    {
        public int IdAtividade { get; set; }    
        public int IdAluno { get; set; }
        public int IdSubTopico { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public Double Nota { get; set; }
        public Double Progresso { get; set; }
        public bool Resposta { get; set; }
    }
}
