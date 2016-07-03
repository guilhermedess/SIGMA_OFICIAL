using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USJT.Sigma.DataAccess;

namespace USJT.Sigma.Repositorio
{
    public class AtividadeREP
    {
        public void AdicionaAtividade(int idAluno, int idSubTopico, string nomeAtividade)
        {
            using (var conexao = new SIGMAEntities())
            {
                var novaAtividade = new TB_ATIVIDADE();

                novaAtividade.ID_ALUNO = idAluno;
                novaAtividade.ID_SUBTOPICO = idSubTopico;
                novaAtividade.NOM_ATIVIDADE = nomeAtividade;
                novaAtividade.NOM_IMAGEM = "nome da imagem";
                conexao.TB_ATIVIDADE.Add(novaAtividade);
                conexao.SaveChanges();      
            }
        }

        public void ExisteAtividade()
        {

        }
    }
}
