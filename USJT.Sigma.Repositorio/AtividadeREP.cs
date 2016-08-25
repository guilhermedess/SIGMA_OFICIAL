using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USJT.Sigma.DataAccess;
using USJT.Sigma.Model;

namespace USJT.Sigma.Repositorio
{
    public class AtividadeREP
    {
        public void AdicionaAtividade(int idAluno, int idSubTopico, string nomeAtividade, double nota)
        {
            using (var conexao = new SIGMAEntities())
            {
                var novaAtividade = new TB_ATIVIDADE();

                novaAtividade.ID_ALUNO = idAluno;
                novaAtividade.ID_SUBTOPICO = idSubTopico;
                novaAtividade.NOM_ATIVIDADE = nomeAtividade;
                novaAtividade.VAL_NOTA = nota;
                novaAtividade.NOM_IMAGEM = "nome da imagem";
                conexao.TB_ATIVIDADE.Add(novaAtividade);
                conexao.SaveChanges();
            }
        }

        public bool ExisteAtividade(int idAluno, string nomeAtividade)
        {
            using (var conexao = new SIGMAEntities())
            {
                var retorno = (from C in conexao.TB_ATIVIDADE
                               where C.ID_ALUNO == idAluno && C.NOM_ATIVIDADE == nomeAtividade
                               select new Atividade
                               {
                                   IdAluno = idAluno
                               }).ToList();

                if (retorno.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //public string ExisteAtividadeFirst(int idAluno, string nomeAtividade)
        //{
        //    using (var conexao = new SIGMAEntities())
        //    {
        //        var retorno = (from C in conexao.TB_ATIVIDADE
        //                       where C.ID_ALUNO == idAluno && C.NOM_ATIVIDADE == nomeAtividade
        //                       select new Atividade
        //                       {
        //                           IdAluno = idAluno,
        //                           IdAtividade = C.ID_ATIVIDADE,
        //                           IdSubTopico = C.ID_SUBTOPICO,
        //                           NomeAtv = C.NOM_ATIVIDADE
        //                       }).ToList().FirstOrDefault();

        //        return retorno.NomeAtv;
        //    }
        //}

        public List<Atividade> AtividadesFeitas(int idAluno)
        {
            using (var conexao = new SIGMAEntities())
            {
                List<Atividade> buscaFeita = (from C in conexao.TB_ATIVIDADE
                                              where C.ID_ALUNO == idAluno
                                              select new Atividade
                                              {
                                                  NomeAtv = C.NOM_ATIVIDADE,
                                                  Nota = (double)C.VAL_NOTA
                                              }).ToList();
                return buscaFeita;
            }

        }

        public List<Atividade> AtividadesFeitasDeUmSubTopico(int idAluno, string parteNomeAtvidade)
        {
            using (var conexao = new SIGMAEntities())
            {
                List<Atividade> buscaFeita = (from C in conexao.TB_ATIVIDADE
                                              where C.ID_ALUNO == idAluno && C.NOM_ATIVIDADE.Contains(parteNomeAtvidade)
                                              select new Atividade
                                              {
                                                  NomeAtv = C.NOM_ATIVIDADE,
                                                  Nota = (double)C.VAL_NOTA
                                              }).ToList();
                return buscaFeita;
            }

        }

    }
}
