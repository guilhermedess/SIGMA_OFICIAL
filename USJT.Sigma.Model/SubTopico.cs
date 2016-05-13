using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USJT.Sigma.Model
{
    public class SubTopico
    {
        public int IdSubTopico { get; set; }
        public Topico IdTopico { get; set; }
        public Video IdVideo { get; set; }
        public Atividade IdAtividade { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }

    }
}
