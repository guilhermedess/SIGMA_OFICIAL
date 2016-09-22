using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using USJT.Sigma.Model;
using USJT.Sigma.Repositorio;

namespace USJT.Sigma.UI.WEB.Controllers
{
    public class AlunoController : Controller
    {
        private AlunoREP alunoREP = new AlunoREP();
        private SubTopicoREP subTopicoREP = new SubTopicoREP();
        AtividadeAlunoREP atividadeAlunoREP = new AtividadeAlunoREP();

        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Aluno dadosAluno)
        {
            try
            {
                alunoREP.Cadastrar(dadosAluno);

                return View(/*pagina*/);
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Editar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Editar(Aluno dadosAluno)
        {
            try
            {
                alunoREP.Editar(dadosAluno);

                return View(/*Pagina*/);
            }
            catch (Exception)
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Login(Aluno dadosLogin)
        {
            var alunoREP = new AlunoREP();

            Session["dadosAlunoLogado"] = alunoREP.buscaDadosAluno(dadosLogin);

            //VERIFICAMOS SE O USUARIO EXISTE
            if (!alunoREP.ValidarLogin(dadosLogin))
            {
                //DISPARAMOS A MENSAGEM DE USUARIO OU SENHA NAO EXISTE
                //TempData.Add("Mensagem", "Usuário ou Senha Invalidos");

                return View();
            }

            //AUTORIZAMOS O USUARIO A ACESSAR AS ACTIONS
            //FormsAuthentication.SetAuthCookie(dadosLogin.Usuário, true);

            //MANDAMOS REDIRECIONAR PARA A ACTION LOGIN
            //return RedirectToAction("Topicos","Topico", dadosLogin);
            return new RedirectToRouteResult(new RouteValueDictionary(
               new { action = "Topicos", controller = "Topico" }));
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Aluno/Login");
        }
        public void CarregarComboDistribuicao()
        {
            IEnumerable<string> opcoes = new string[] { "O - Todas", "X - Todas Pendentes", "1 - Introdução e Conceitos", "2 - Dist. Pontos ou valores", "3 - Classes ou intervalos",
                         "4.1 - Freq. relativa ou percentual", "4.2 - Acum. simples ou absoluta", "4.3 - Acum. relativa ou percentual",
                         "5.1 - Freq. por pontos ou valores", "5.2 - Freq. por classes ou intervalos"};

            ViewBag.opcoesDistribuicao = new SelectList(opcoes);
        }
        public void CarregarComboTendencia()
        {
            IEnumerable<string> opcoes = new string[] { "O - Todas", "X - Todas Pendentes", "1 - Introdução", "2.1 - Média simples",
                "2.2 - Média ponderada", "3 - Moda", "4 - Mediana"};

            ViewBag.OpcoesTendencia = new SelectList(opcoes);
        }
        public ActionResult Progresso()
        {
            Aluno dadosAlunoLogado = (Aluno)Session["dadosAlunoLogado"];

            AtividadeAlunoREP atividadeAlunoREP = new AtividadeAlunoREP();
            AtividadeREP atividadeREP = new AtividadeREP();
            AlunoREP alunoREP = new AlunoREP();

            dadosAlunoLogado.TotalPontosFeitos = atividadeAlunoREP.PontosFeitos(dadosAlunoLogado.IdAluno);
            dadosAlunoLogado.ProgressoTotal = alunoREP.ProgressoTotal(dadosAlunoLogado.IdAluno);

            dadosAlunoLogado.ProgressoDistribuicao = alunoREP.ProgressoDeUmTopico(dadosAlunoLogado.IdAluno, 1);
            dadosAlunoLogado.ProgressoMedidasDeTendenciaCentral = alunoREP.ProgressoDeUmTopico(dadosAlunoLogado.IdAluno, 2);
            //dadosAlunoLogado.ProgressoMedidasDeDispersao = alunoREP.ProgressoDeUmTopico(dadosAlunoLogado.IdAluno, 3);
            //dadosAlunoLogado.ProgressoAmostragemEstimadores = alunoREP.ProgressoDeUmTopico(dadosAlunoLogado.IdAluno, 4);

            dadosAlunoLogado.PontosDistribuicao = atividadeREP.TotalPontosPossiveisDeUmTopico(1);
            dadosAlunoLogado.PontosMedidasDeTendenciaCentral = atividadeREP.TotalPontosPossiveisDeUmTopico(2);
            //dadosAlunoLogado.PontosMedidasDeDispersao = atividadeREP.TotalPontosPossiveisDeUmTopico(3);
            //dadosAlunoLogado.PontosAmostragemEstimadores = atividadeREP.TotalPontosPossiveisDeUmTopico(4);

            dadosAlunoLogado.PontosFeitosDistribuicao = atividadeAlunoREP.PontosFeitosDeUmTopico(dadosAlunoLogado.IdAluno, 1);
            dadosAlunoLogado.PontosFeitosMedidasDeTendenciaCentral = atividadeAlunoREP.PontosFeitosDeUmTopico(dadosAlunoLogado.IdAluno, 2);
            //dadosAlunoLogado.PontosFeitosMedidasDeDispersao = atividadeAlunoREP.PontosFeitosDeUmTopico(dadosAlunoLogado.IdAluno, 3);
            //dadosAlunoLogado.PontosFeitosAmostragemEstimadores = atividadeAlunoREP.PontosFeitosDeUmTopico(dadosAlunoLogado.IdAluno, 4);

            dadosAlunoLogado.PDIntroducao = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 1);
            dadosAlunoLogado.PDPontosValores = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 2);
            dadosAlunoLogado.PDClassesIntervalos = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 3);
            dadosAlunoLogado.PDRelativaPercentual = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 4);
            dadosAlunoLogado.PDAcumuladaSimplesAbsoluta = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 5);
            dadosAlunoLogado.PDAcumuladaRelativaPercentual = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 6);
            dadosAlunoLogado.PDFreqPontosValores = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 7);
            dadosAlunoLogado.PDFreqClassesIntervalos = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 8);

            dadosAlunoLogado.PTIntroducao = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 9);
            dadosAlunoLogado.PTMediaSimples = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 10);
            dadosAlunoLogado.PTMediaPonderada = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 11);
            dadosAlunoLogado.PTModa = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 12);
            dadosAlunoLogado.PTMediana = alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 13);


            dadosAlunoLogado.ProgressoDistribuicaoPorAtividade = alunoREP.ProgressoDeUmTopicoPorQuantidade(dadosAlunoLogado.IdAluno, 1);
            dadosAlunoLogado.ProgressoMedidasDeTendenciaPorAtividade = alunoREP.ProgressoDeUmTopicoPorQuantidade(dadosAlunoLogado.IdAluno, 2);

            dynamic meusModelos = new ExpandoObject();
            meusModelos.Aluno = dadosAlunoLogado;

            return View(meusModelos);
        }
        [HttpPost]
        public ActionResult Atividades(Aluno aluno, string comboDistribuicao, string comboTendencia)
        {
            try
            {
                var valorComboDistribuicao = ValidarComboDistribuicao(comboDistribuicao);
                var valorComboTendencia = ValidarComboTendencia(comboTendencia);

                AtividadeREP atividadeREP = new AtividadeREP();
                dynamic meusModelos = new ExpandoObject();

                aluno = (Aluno)Session["dadosAlunoLogado"];

                if (comboDistribuicao != null)
                {
                    aluno.topicoSelecionadoAtv = 1;
                }
                else
                {
                    if (comboTendencia != null)
                    {
                        aluno.topicoSelecionadoAtv = 2;
                    }
                }

                meusModelos.Aluno = (Aluno)Session["dadosAlunoLogado"];

                if (valorComboDistribuicao == -1 || valorComboTendencia == -1)
                {

                }
                else
                {
                    if (valorComboDistribuicao == 0 || valorComboTendencia == 0)
                    {
                        meusModelos.atividadesFeitasDistribuicao = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 1);
                        meusModelos.todasAtividadesDistribuicao = atividadeREP.TodasAtividadesDeUmTopico(1);

                        meusModelos.atividadesFeitasTendencia = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 2);
                        meusModelos.todasAtividadesTendencia = atividadeREP.TodasAtividadesDeUmTopico(2);
                    }
                    else
                    {
                        if (valorComboDistribuicao != 0 && valorComboDistribuicao != -100)
                        {
                            meusModelos.todasAtividadesDistribuicao = atividadeREP.TodasAtividadesDeUmSubTopico(valorComboDistribuicao);
                            meusModelos.atividadesFeitasDistribuicao = atividadeAlunoREP.AtividadesFeitasDeUmSubTopico(aluno.IdAluno, valorComboDistribuicao);

                            meusModelos.atividadesFeitasTendencia = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 2);
                            meusModelos.todasAtividadesTendencia = atividadeREP.TodasAtividadesDeUmTopico(2);
                        }
                        else
                        {
                            if (valorComboTendencia != 0 && valorComboTendencia != -100)
                            {
                                meusModelos.todasAtividadesTendencia = atividadeREP.TodasAtividadesDeUmSubTopico(valorComboTendencia);
                                meusModelos.atividadesFeitasTendencia = atividadeAlunoREP.AtividadesFeitasDeUmSubTopico(aluno.IdAluno, valorComboTendencia);

                                meusModelos.atividadesFeitasDistribuicao = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 1);
                                meusModelos.todasAtividadesDistribuicao = atividadeREP.TodasAtividadesDeUmTopico(1);
                            }

                        }
                    }
                }

                CarregarComboDistribuicao();
                CarregarComboTendencia();
                

                return View(meusModelos);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        public ActionResult Atividades(Aluno aluno)
        {
            try
            {
                CarregarComboDistribuicao();
                CarregarComboTendencia();

                AtividadeREP atividadeREP = new AtividadeREP();

                dynamic meusModelos = new ExpandoObject();

                aluno = (Aluno)Session["dadosAlunoLogado"];
                aluno.topicoSelecionadoAtv = 1;

                meusModelos.Aluno = (Aluno)Session["dadosAlunoLogado"];

                meusModelos.atividadesFeitasDistribuicao = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 1);
                meusModelos.todasAtividadesDistribuicao = atividadeREP.TodasAtividadesDeUmTopico(1);

                meusModelos.atividadesFeitasTendencia = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 2);
                meusModelos.todasAtividadesTendencia = atividadeREP.TodasAtividadesDeUmTopico(2);

                return View(meusModelos);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        public dynamic AtualizarAtividades(Aluno aluno, string comboDistribuicao)
        {
            try
            {
                var procurarAtv = ValidarComboDistribuicao(comboDistribuicao);

                AtividadeREP atividadeREP = new AtividadeREP();
                dynamic meusModelos = new ExpandoObject();

                aluno = (Aluno)Session["dadosAlunoLogado"];
                meusModelos.Aluno = (Aluno)Session["dadosAlunoLogado"];

                if (procurarAtv == 0)
                {
                    //meusModelos.atividadesFeitas = atividadeAlunoREP.AtividadesFeitas(aluno.IdAluno);

                    //var x = atividadeREP.TodasAtividades();

                    //for (int i = 0; i < x.Count - 1; i++)
                    //{
                    //    x.Remove(meusModelos.atividadesFeitas[i].Atividade);
                    //}

                    //meusModelos.atividadesFeitas = x;
                }
                else
                {
                    if (procurarAtv == 99)
                    {
                        meusModelos.todasAtividades = atividadeREP.TodasAtividades();
                        meusModelos.atividadesFeitas = atividadeAlunoREP.AtividadesFeitas(aluno.IdAluno);
                    }
                    else
                    {
                        meusModelos.todasAtividades = atividadeREP.TodasAtividadesDeUmSubTopico(procurarAtv);
                        meusModelos.atividadesFeitas = atividadeAlunoREP.AtividadesFeitasDeUmSubTopico(aluno.IdAluno, procurarAtv);
                    }
                }

                CarregarComboDistribuicao();

                return meusModelos;

            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        public int ValidarComboDistribuicao(string comboDistribuicao)
        {
            if (comboDistribuicao == null)
            {
                comboDistribuicao = "";
            }

            int procurarAtv = -100;

            if (comboDistribuicao.Equals("O - Todas"))
            {
                procurarAtv = 0;
            }
            else
            {
                if (comboDistribuicao.Equals("X - Todas Pendentes"))
                {
                    procurarAtv = -1;
                }
                else
                {
                    if (comboDistribuicao.Equals("1 - Introdução e Conceitos"))
                    {
                        procurarAtv = 1;
                    }
                    else
                    {
                        if (comboDistribuicao.Equals("2 - Dist. Pontos ou valores"))
                        {
                            procurarAtv = 2;
                        }
                        else
                        {
                            if (comboDistribuicao.Equals("3 - Classes ou intervalos"))
                            {
                                procurarAtv = 3;
                            }
                            else
                            {
                                if (comboDistribuicao.Equals("4.1 - Freq. relativa ou percentual"))
                                {
                                    procurarAtv = 4;
                                }
                                else
                                {
                                    if (comboDistribuicao.Equals("4.2 - Acum. simples ou absoluta"))
                                    {
                                        procurarAtv = 5;
                                    }
                                    else
                                    {
                                        if (comboDistribuicao.Equals("4.3 - Acum. relativa ou percentual"))
                                        {
                                            procurarAtv = 6;
                                        }
                                        else
                                        {
                                            if (comboDistribuicao.Equals("5.1 - Freq. por pontos ou valores"))
                                            {
                                                procurarAtv = 7;
                                            }
                                            else
                                            {
                                                if (comboDistribuicao.Equals("5.2 - Freq. por classes ou intervalos"))
                                                {
                                                    procurarAtv = 8;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return procurarAtv;
        }
        public int ValidarComboTendencia(string comboTendencia)
        {
            if (comboTendencia == null)
            {
                comboTendencia = "";
            }

            int procurarAtv = -100;

            if (comboTendencia.Equals("O - Todas"))
            {
                procurarAtv = 0;
            }
            else
            {
                if (comboTendencia.Equals("X - Todas Pendentes"))
                {
                    procurarAtv = -1;
                }
                else
                {
                    if (comboTendencia.Equals("1 - Introdução"))
                    {
                        procurarAtv = 9;
                    }
                    else
                    {
                        if (comboTendencia.Equals("2.1 - Média simples"))
                        {
                            procurarAtv = 10;
                        }
                        else
                        {
                            if (comboTendencia.Equals("2.2 - Média ponderada"))
                            {
                                procurarAtv = 11;
                            }
                            else
                            {
                                if (comboTendencia.Equals("3 - Moda"))
                                {
                                    procurarAtv = 12;
                                }
                                else
                                {
                                    if (comboTendencia.Equals("4 - Mediana"))
                                    {
                                        procurarAtv = 13;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return procurarAtv;
        }
       
    }
}