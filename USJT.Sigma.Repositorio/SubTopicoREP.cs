using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USJT.Sigma.DataAccess;
using USJT.Sigma.Model;

namespace USJT.Sigma.Repositorio
{
    public class SubTopicoREP
    {
        public void checkSubTopico(Aluno aluno, bool feito)
        {
            using (var conexao = new SIGMAEntities())
            {
                var alunoNovo = conexao.TB_ALUNO.Single(x => x.ID_ALUNO == 5);

                var novo = conexao.TB_SUBTOPICO.Single(x => x.ID_SUBTOPICO == 9);
                
                //var novo = new TB_SUBTOPICO();

                novo.CHK_STATUS = feito;

                conexao.SaveChanges();
            }
        }
    }
}
