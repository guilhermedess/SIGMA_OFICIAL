using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USJT.Sigma.DataAccess;
using USJT.Sigma.Model;

namespace USJT.Sigma.Repositorio
{
    public class TopicoREP
    {
        public int AdicionaTopico(TB_ALUNO aluno, string nomeTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                //var alunoNovo = conexao.TB_ALUNO.Single(x => x.ID_ALUNO == aluno.IdAluno);

                //verificar se o topico já existe, adiciono na tabela Topico uma linha 

                var idTopicoProcurado = ExisteTopico(aluno.ID_ALUNO, nomeTopico);
                if (idTopicoProcurado == 0)
                {
                    var novoTopico = new TB_TOPICO();

                    novoTopico.ID_ALUNO = aluno.ID_ALUNO;
                    novoTopico.NOM_TOPICO = nomeTopico;

                    conexao.TB_TOPICO.Add(novoTopico);
                    conexao.SaveChanges();

                    return novoTopico.ID_TOPICO;
                }
                else
                {
                    return idTopicoProcurado;
                }
            }
        }

        public int ExisteTopico(int idAluno, string nomeTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                //var retorno = (from C in conexao.TB_TOPICO
                //               where C.ID_ALUNO == idAluno && C.NOM_TOPICO == nomeTopico
                //               select new Topico
                //               {
                //                   IdAluno = idAluno,
                //                   Nome = nomeTopico,
                //               }).ToList();

                var retorno = from A in conexao.TB_TOPICO
                          where A.ID_ALUNO == idAluno && A.NOM_TOPICO == nomeTopico
                          select A;

                //Topico topicoRecuperado;
                int idTopicoRecuperado = 0;

                foreach (var aux in retorno)
                    idTopicoRecuperado = (int) aux.ID_TOPICO;

                return idTopicoRecuperado;
            }
        }
    }
}
