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
        public List<Atividade> TodasAtividadesDeUmTopico(int idTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                List<Atividade> atividadeFeitas =
                    (from C in conexao.TB_ATIVIDADE
                     where C.TB_SUBTOPICO.TB_TOPICO.ID_TOPICO == idTopico
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
                var atividadeRecuperada = conexao.TB_ATIVIDADE.Single(modelAtividade => modelAtividade.ID_ATIVIDADE == idAtividade);               

                return atividadeRecuperada.DES_RESPOSTA;
            }
        }
        public double TotalPontos()
        {
            using (var conexao = new SIGMAEntities())
            {
                var totalNotas = (from C in conexao.TB_ATIVIDADE
                                  select new Atividade
                                  {
                                      Nota = (double)C.VAL_NOTA
                                  }).ToList();

                return totalNotas.Sum(x => x.Nota);
            }
        }
        public double TotalPontosPossiveisDeUmTopico(int idTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                var totalNotas = (from C in conexao.TB_ATIVIDADE
                                  where C.TB_SUBTOPICO.TB_TOPICO.ID_TOPICO == idTopico
                                  select new Atividade
                                  {
                                      Nota = (double)C.VAL_NOTA
                                  }).ToList();

                return totalNotas.Sum(x => x.Nota);
            }
        }
        public double TotalPontosPossiveisDeUmSubTopico(int idSubTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                var totalNotas = (from C in conexao.TB_ATIVIDADE
                                  where C.TB_SUBTOPICO.ID_SUBTOPICO == idSubTopico
                                  select new Atividade
                                  {
                                      Nota = (double)C.VAL_NOTA
                                  }).ToList();

                return totalNotas.Sum(x => x.Nota);
            }
        }
        public int TotalAtividadeDeUmTopico(int idTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                var totalAtividades = (from C in conexao.TB_ATIVIDADE
                                  where C.TB_SUBTOPICO.TB_TOPICO.ID_TOPICO == idTopico
                                  select new Atividade { }).ToList();

                return totalAtividades.Count;
            }
        }
    }
}
