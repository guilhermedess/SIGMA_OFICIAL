﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using USJT.Sigma.DataAccess;
using USJT.Sigma.Model;

namespace USJT.Sigma.Repositorio
{
    public class AtividadeAlunoREP
    {
        public List<AtividadeAluno> AtividadesFeitas(int idAluno)
        {
            using (var conexao = new SIGMAEntities())
            {
                List<AtividadeAluno> atividadeFeitas =
                    (from C in conexao.TB_ATIVIDADE_ALUNO
                     where C.ID_ALUNO == idAluno && C.CHK_STATUS == true
                     select new AtividadeAluno
                     {
                         IdAtividadeAluno = C.ID_ATIVIDADE_ALUNO,
                         IdAtividade = C.ID_ATIVIDADE,
                         IdAluno = C.ID_ALUNO,
                         Atividade = new Atividade
                         {
                             IdAtividade = C.ID_ATIVIDADE,
                             NomeAtv = C.TB_ATIVIDADE.NOM_ATIVIDADE,
                             DescricaoTitulo = C.TB_ATIVIDADE.DES_TITULO,
                             DescricaoSubTitulo = C.TB_ATIVIDADE.DES_SUBTITULO,
                             DescricaoAtividade = C.TB_ATIVIDADE.DES_ATIVIDADE,
                             DescricaoPergunta = C.TB_ATIVIDADE.DES_PERGUNTA,
                             Nota = (double)C.TB_ATIVIDADE.VAL_NOTA
                         }
                     }).ToList();
                return atividadeFeitas;
            }
        }
        public List<AtividadeAluno> AtividadesFeitasPorData(int idAluno)
        {
            using (var conexao = new SIGMAEntities())
            {
                var umaSemana = DateTime.Now.AddDays(-7.0);

                List<AtividadeAluno> atividadeFeitas =
                    (from C in conexao.TB_ATIVIDADE_ALUNO
                     where C.ID_ALUNO == idAluno && C.CHK_STATUS == true && (C.DAT_REALIZACAO >= umaSemana) //continuar
                     select new AtividadeAluno
                     {
                         IdAtividadeAluno = C.ID_ATIVIDADE_ALUNO,
                         IdAtividade = C.ID_ATIVIDADE,
                         IdAluno = C.ID_ALUNO,
                         Atividade = new Atividade
                         {
                             IdAtividade = C.ID_ATIVIDADE,
                             NomeAtv = C.TB_ATIVIDADE.NOM_ATIVIDADE,
                             DescricaoTitulo = C.TB_ATIVIDADE.DES_TITULO,
                             DescricaoSubTitulo = C.TB_ATIVIDADE.DES_SUBTITULO,
                             DescricaoAtividade = C.TB_ATIVIDADE.DES_ATIVIDADE,
                             DescricaoPergunta = C.TB_ATIVIDADE.DES_PERGUNTA,
                             Nota = (double)C.TB_ATIVIDADE.VAL_NOTA
                         }
                     }).ToList();
                return atividadeFeitas;
            }
        }
        public List<AtividadeAluno> ListaAtividadesFeitasDeUmTopico(int idAluno, int idTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                List<AtividadeAluno> atividadeFeitas =
                    (from C in conexao.TB_ATIVIDADE_ALUNO
                     where C.ID_ALUNO == idAluno && C.TB_ATIVIDADE.TB_SUBTOPICO.TB_TOPICO.ID_TOPICO == idTopico && C.CHK_STATUS == true
                     select new AtividadeAluno
                     {
                         IdAtividadeAluno = C.ID_ATIVIDADE_ALUNO,
                         IdAtividade = C.ID_ATIVIDADE,
                         IdAluno = C.ID_ALUNO,
                         Atividade = new Atividade
                         {
                             IdAtividade = C.ID_ATIVIDADE,
                             NomeAtv = C.TB_ATIVIDADE.NOM_ATIVIDADE,
                             DescricaoTitulo = C.TB_ATIVIDADE.DES_TITULO,
                             DescricaoSubTitulo = C.TB_ATIVIDADE.DES_SUBTITULO,
                             DescricaoAtividade = C.TB_ATIVIDADE.DES_ATIVIDADE,
                             DescricaoPergunta = C.TB_ATIVIDADE.DES_PERGUNTA,
                             Nota = (double)C.TB_ATIVIDADE.VAL_NOTA
                         }
                     }).ToList();
                return atividadeFeitas;
            }
        }
        public List<AtividadeAluno> AtividadesFeitasDeUmSubTopico(int idAluno, int idSubTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                List<AtividadeAluno> atividadeFeitas =
                    (from C in conexao.TB_ATIVIDADE_ALUNO
                     where C.ID_ALUNO == idAluno && C.TB_ATIVIDADE.ID_SUBTOPICO == idSubTopico && C.CHK_STATUS == true
                     select new AtividadeAluno
                     {
                         IdAtividadeAluno = C.ID_ATIVIDADE_ALUNO,
                         IdAluno = C.ID_ALUNO,
                         Atividade = new Atividade
                         {
                             IdAtividade = C.ID_ATIVIDADE,
                             NomeAtv = C.TB_ATIVIDADE.NOM_ATIVIDADE,
                             DescricaoTitulo = C.TB_ATIVIDADE.DES_TITULO,
                             DescricaoSubTitulo = C.TB_ATIVIDADE.DES_SUBTITULO,
                             DescricaoAtividade = C.TB_ATIVIDADE.DES_ATIVIDADE,
                             DescricaoPergunta = C.TB_ATIVIDADE.DES_PERGUNTA,
                             Nota = (double)C.TB_ATIVIDADE.VAL_NOTA
                         }
                     }).ToList();
                return atividadeFeitas;
            }
        }
        public bool ExisteAtividadeFeita(int idAluno, int IdAtividade)
        {
            using (var conexao = new SIGMAEntities())
            {
                AtividadeAluno retorno = null;

                try
                {
                    retorno = (from C in conexao.TB_ATIVIDADE_ALUNO
                               where C.ID_ALUNO == idAluno && C.ID_ATIVIDADE == IdAtividade && C.CHK_STATUS == true
                               //      C.NOM_ATIVIDADE.Equals(atividade.NomeAtv) && C.NOM_TITULO.Equals(atividade.NomeTitulo) &&
                               //      C.NOM_SUBTITULO.Equals(atividade.NomeSubTitulo) && C.NOM_DESCRICAO.Equals(atividade.NomeDescricao)
                               select new AtividadeAluno
                               {
                                   IdAluno = idAluno,
                                   Atividade = new Atividade
                                   {
                                       NomeAtv = C.TB_ATIVIDADE.NOM_ATIVIDADE,
                                       Nota = (double)C.TB_ATIVIDADE.VAL_NOTA                                       
                                   }
                               }).ToList().First();

                    if (retorno == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    //só cai aqui caso o banco esteja vazio pois estoura exception no sql
                    if (retorno == null)
                    {
                        return false;
                    }
                    throw;
                }
            }
        }
        public void AdicionaAtividadeAluno(int idAluno, int IdAtividade)
        {
            using (var conexao = new SIGMAEntities())
            {
                var novaAtividadeAluno = new TB_ATIVIDADE_ALUNO();

                novaAtividadeAluno.ID_ALUNO = idAluno;
                novaAtividadeAluno.ID_ATIVIDADE = IdAtividade;
                novaAtividadeAluno.CHK_STATUS = true;
                novaAtividadeAluno.DAT_REALIZACAO = DateTime.Now;
                conexao.TB_ATIVIDADE_ALUNO.Add(novaAtividadeAluno);
                conexao.SaveChanges();
            }
        }
        public double PontosFeitos(int idAluno)
        {
            using (var conexao = new SIGMAEntities())
            {
                var totalFeito = (from C in conexao.TB_ATIVIDADE_ALUNO
                                  where C.ID_ALUNO == idAluno
                                  select new AtividadeAluno
                                  {
                                      Atividade = new Atividade
                                      {
                                          Nota = (double)C.TB_ATIVIDADE.VAL_NOTA
                                      }
                                  }).ToList();

                return totalFeito.Sum(x => x.Atividade.Nota);
            }
        }
        public double PontosFeitosDeUmTopico(int idAluno, int idTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                var totalFeito = (from C in conexao.TB_ATIVIDADE_ALUNO
                                  where C.ID_ALUNO == idAluno && C.TB_ATIVIDADE.TB_SUBTOPICO.ID_TOPICO == idTopico
                                  select new AtividadeAluno
                                  {
                                      Atividade = new Atividade
                                      {
                                          Nota = (double)C.TB_ATIVIDADE.VAL_NOTA
                                      }
                                  }).ToList();

                return totalFeito.Sum(x => x.Atividade.Nota);
            }
        }
        public double PontosFeitosDeUmSubTopico(int idAluno, int idSubTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                var totalFeito = (from C in conexao.TB_ATIVIDADE_ALUNO
                                  where C.ID_ALUNO == idAluno && C.TB_ATIVIDADE.ID_SUBTOPICO == idSubTopico
                                  select new AtividadeAluno
                                  {
                                      Atividade = new Atividade
                                      {
                                          Nota = (double)C.TB_ATIVIDADE.VAL_NOTA
                                      }
                                  }).ToList();

                return totalFeito.Sum(x => x.Atividade.Nota);
            }
        }
        public int AtividadesFeitasDeUmTopico(int idAluno, int idTopico)
        {
            using (var conexao = new SIGMAEntities())
            {
                var totalAtividadesFeitas = (from C in conexao.TB_ATIVIDADE_ALUNO
                                  where C.ID_ALUNO == idAluno && C.TB_ATIVIDADE.TB_SUBTOPICO.ID_TOPICO == idTopico
                                  select new AtividadeAluno { }).ToList();

                return totalAtividadesFeitas.Count;
            }
        }
    }
}
