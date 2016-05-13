using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USJT.Sigma.Model
{
    public class Certificado
    {
        public int IdCertificado { get; set; }
        public Aluno IdAluno { get; set; }
        public string URL { get; set; }

    }
}
