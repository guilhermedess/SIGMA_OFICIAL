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
        public void AdicionaSubTopico(Aluno aluno, string nomeTopico, string nomeSubTopico, bool feito)
        {
            using (var conexao = new SIGMAEntities())
            {
                var alunoNovo = conexao.TB_ALUNO.Single(x => x.ID_ALUNO == aluno.IdAluno);

                //verificar se o subtopico já existe
                //check == true -> adiciono na tabela SubTopico uma linha 
                if (ExisteSubTopico(alunoNovo.ID_ALUNO, nomeSubTopico))
                {
                    if (feito == true)
                    {
                        //verifica se o topico existe
                        TopicoREP topicoREP = new TopicoREP();
                        int idTopicoResgatado = topicoREP.AdicionaTopico(alunoNovo, nomeTopico);

                        var novoSubTopico = new TB_SUBTOPICO();

                        novoSubTopico.ID_ALUNO = alunoNovo.ID_ALUNO;
                        novoSubTopico.ID_TOPICO = idTopicoResgatado;
                        //novoSubTopico.ID_VIDEO 
                        //novoSubTopico.ID_ATIVIDADE
                        novoSubTopico.NOM_SUBTOPICO = nomeSubTopico;
                        //novoSubTopico.QTD_PROGRESSO
                        novoSubTopico.CHK_STATUS = true;

                        conexao.TB_SUBTOPICO.Add(novoSubTopico);
                        conexao.SaveChanges();
                    }
                }
            }
        }

        public bool ExisteSubTopico(int idAluno, string nomeSubTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                var retorno = (from C in conexao.TB_SUBTOPICO
                               where C.ID_ALUNO == idAluno && C.NOM_SUBTOPICO == nomeSubTopico
                               select new SubTopico
                               {
                                   IdAluno = idAluno,
                                   Nome = nomeSubTopico,
                                   //IdAtividade = C.ID_ATIVIDADE,
                                   IdSubTopico = C.ID_SUBTOPICO,
                                   IdTopico = new Topico
                                   {
                                       IdTopico = C.ID_TOPICO
                                   }
                                   //IdVideo = C.ID_VIDEO,
                                   //Status = C.CHK_STATUS
                               }).ToList();

                if (retorno.Count != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
    }
}
