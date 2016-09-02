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
        //public void AdicionaAtividade(int idAluno, int idSubTopico, string nomeAtividade, double nota)
        //{
        //    using (var conexao = new SIGMAEntities())
        //    {
        //        var novaAtividade = new TB_ATIVIDADE();

        //        novaAtividade.ID_ALUNO = idAluno;
        //        novaAtividade.ID_SUBTOPICO = idSubTopico;
        //        novaAtividade.NOM_ATIVIDADE = nomeAtividade;
        //        novaAtividade.VAL_NOTA = nota;
        //        conexao.TB_ATIVIDADE.Add(novaAtividade);
        //        conexao.SaveChanges();
        //    }
        //}

        //public bool ExisteAtividade(int idAluno, Atividade atividade)
        //{
        //    using (var conexao = new SIGMAEntities())
        //    {
        //        var retorno = (from C in conexao.TB_ATIVIDADE_ALUNO
        //                       where C.ID_ALUNO == idAluno && C.ID_ATIVIDADE == atividade.IdAtividade //&&
        //                       //      C.NOM_ATIVIDADE.Equals(atividade.NomeAtv) && C.NOM_TITULO.Equals(atividade.NomeTitulo) &&
        //                       //      C.NOM_SUBTITULO.Equals(atividade.NomeSubTitulo) && C.NOM_DESCRICAO.Equals(atividade.NomeDescricao)
        //                       select new AtividadeAluno
        //                       {
        //                           IdAluno = idAluno
        //                       }).ToList().First();

        //        if (retorno == null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
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

        public List<Atividade> TodasAtividades()
        {
            using (var conexao = new SIGMAEntities())
            {
                List<Atividade> atividadeFeitas =
                    (from C in conexao.TB_ATIVIDADE
                     select new Atividade
                     {
                         IdAtividade = C.ID_ATIVIDADE,
                         NomeAtv = C.NOM_ATIVIDADE,
                         DescricaoTitulo = C.DES_TITULO,
                         DescricaoSubTitulo = C.DES_SUBTITULO,
                         DescricaoAtividade = C.DES_ATIVIDADE,
                         DescricaoPergunta = C.DES_PERGUNTA,
                         Nota = (double)C.VAL_NOTA
                     }).ToList();
                return atividadeFeitas;
            }
        }

        public List<Atividade> TodasAtividadesDeUmSubTopico(int idSubTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                List<Atividade> atividadeFeitas =
                    (from C in conexao.TB_ATIVIDADE
                     where C.ID_SUBTOPICO == idSubTopico
                     orderby C.NUM_PERGUNTA ascending
                     select new Atividade
                     {
                         IdAtividade = C.ID_ATIVIDADE,
                         NomeAtv = C.NOM_ATIVIDADE,
                         DescricaoTitulo = C.DES_TITULO,
                         DescricaoSubTitulo = C.DES_SUBTITULO,
                         DescricaoAtividade = C.DES_ATIVIDADE,
                         DescricaoPergunta = C.DES_PERGUNTA,
                         Nota = (double)C.VAL_NOTA
                     }).ToList();
                return atividadeFeitas;
            }
        }
        public string RespostaExata(int idAtividade)
        {
            using (var conexao = new SIGMAEntities())
            {
                var atividadeRecuperada = conexao.TB_ATIVIDADE.Single(modelAtividade => modelAtividade.ID_ATIVIDADE.Equals(idAtividade));               

                return atividadeRecuperada.DES_RESPOSTA;
            }
        }

    }
}
