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
        AtividadeREP atividadeREP = new AtividadeREP();

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
               new { action = "Apresentacao", controller = "Aluno" }));
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {         
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
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
            try
            {
                Aluno dadosAlunoLogado = (Aluno)Session["dadosAlunoLogado"];

                AtividadeAlunoREP atividadeAlunoREP = new AtividadeAlunoREP();
                AtividadeREP atividadeREP = new AtividadeREP();
                AlunoREP alunoREP = new AlunoREP();

                dadosAlunoLogado.TotalPontosFeitos = atividadeAlunoREP.PontosFeitos(dadosAlunoLogado.IdAluno);
                dadosAlunoLogado.ProgressoTotal = Math.Round(alunoREP.ProgressoTotal(dadosAlunoLogado.IdAluno), 2);

                dadosAlunoLogado.ProgressoDistribuicao = Math.Round(alunoREP.ProgressoDeUmTopico(dadosAlunoLogado.IdAluno, 1), 2);
                dadosAlunoLogado.ProgressoMedidasDeTendenciaCentral = Math.Round(alunoREP.ProgressoDeUmTopico(dadosAlunoLogado.IdAluno, 2), 2);
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

                dadosAlunoLogado.PDIntroducao = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 1), 2);
                dadosAlunoLogado.PDPontosValores = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 2), 2);
                dadosAlunoLogado.PDClassesIntervalos = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 3), 2);
                dadosAlunoLogado.PDRelativaPercentual = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 4), 2);
                dadosAlunoLogado.PDAcumuladaSimplesAbsoluta = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 5), 2);
                dadosAlunoLogado.PDAcumuladaRelativaPercentual = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 6), 2);
                dadosAlunoLogado.PDFreqPontosValores = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 7), 2);
                dadosAlunoLogado.PDFreqClassesIntervalos = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 8), 2);

                dadosAlunoLogado.PTIntroducao = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 9), 2);
                dadosAlunoLogado.PTMediaSimples = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 10), 2);
                dadosAlunoLogado.PTMediaPonderada = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 11), 2);
                dadosAlunoLogado.PTModa = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 12), 2);
                dadosAlunoLogado.PTMediana = Math.Round(alunoREP.ProgressoDeUmSubTopico(dadosAlunoLogado.IdAluno, 13), 2);

                dadosAlunoLogado.ProgressoDistribuicaoPorAtividade = alunoREP.ProgressoDeUmTopicoPorQuantidade(dadosAlunoLogado.IdAluno, 1);
                dadosAlunoLogado.ProgressoMedidasDeTendenciaPorAtividade = alunoREP.ProgressoDeUmTopicoPorQuantidade(dadosAlunoLogado.IdAluno, 2);

                dynamic meusModelos = new ExpandoObject();
                meusModelos.Aluno = dadosAlunoLogado;

                return View(meusModelos);
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Aluno");
            }
            
        }
        [HttpPost]
        public ActionResult Atividades(Aluno aluno, string comboDistribuicao, string comboTendencia)
        {
            try
            {
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

                dynamic meusModelos = new ExpandoObject();

                var valorComboDistribuicao = ValidarComboDistribuicao(comboDistribuicao);
                var valorComboTendencia = ValidarComboTendencia(comboTendencia);
                
                meusModelos.Aluno = (Aluno)Session["dadosAlunoLogado"];
                
                AtividadesProcuradas(aluno, meusModelos, valorComboDistribuicao, valorComboTendencia);

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

                dynamic meusModelos = new ExpandoObject();

                aluno = (Aluno)Session["dadosAlunoLogado"];
                aluno.topicoSelecionadoAtv = 1;
                
                List<Atividade> todasAtividadesDist = atividadeREP.TodasAtividadesDeUmTopico(1);
                meusModelos.todasAtividadesDistribuicao = todasAtividadesDist;

                List<AtividadeAluno> atividadesFeitasDist = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 1);
                meusModelos.atividadesFeitasDistribuicao = atividadesFeitasDist;

                List<Atividade> todasAtividadesTend = atividadeREP.TodasAtividadesDeUmTopico(2);
                meusModelos.todasAtividadesTendencia = todasAtividadesTend;

                List<AtividadeAluno> atividadesFeitasTend = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 2);
                meusModelos.atividadesFeitasTendencia = atividadesFeitasTend;

                double aux = 0;
                foreach (var lista in atividadesFeitasDist)
                {
                    aux += lista.Atividade.Nota;
                }
                aluno.PontosFeitosDistribuicao = aux;

                double aux2 = 0;
                foreach (var lista in todasAtividadesDist)
                {
                    aux2 += lista.Nota;
                }
                aluno.PontosDistribuicao = aux2;

                double aux3 = 0;
                foreach (var lista in atividadesFeitasTend)
                {
                    aux3 += lista.Atividade.Nota;
                }
                aluno.PontosFeitosMedidasDeTendenciaCentral = aux3;

                double aux4 = 0;
                foreach (var lista in todasAtividadesTend)
                {
                    aux4 += lista.Nota;
                }
                aluno.PontosMedidasDeTendenciaCentral = aux4;

                meusModelos.Aluno = (Aluno)Session["dadosAlunoLogado"];

                return View(meusModelos);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        public ActionResult Apresentacao()
        {
            return View();
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
        public void AtividadesProcuradas(Aluno aluno, dynamic meusModelos, int valorComboDistribuicao, int valorComboTendencia)
        {
            if (valorComboDistribuicao == -1)
            {
                List<AtividadeAluno> listaDeAtividadesFeitas = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 1);
                List<Atividade> listaDeTodasAtividades = atividadeREP.TodasAtividadesDeUmTopico(1);

                foreach (var feitas in listaDeAtividadesFeitas)
                {
                    for (int i = 0; i < listaDeTodasAtividades.Count; i++)
                    {
                        if (listaDeTodasAtividades[i].IdAtividade == feitas.IdAtividade)
                        {
                            int index = listaDeTodasAtividades.IndexOf(listaDeTodasAtividades[i]);
                            listaDeTodasAtividades.RemoveAt(index);
                        }
                    }
                }

                double aux = 0;
                foreach(var lista in listaDeTodasAtividades)
                {
                    aux += lista.Nota;
                }
                aluno.PontosDistribuicao = aux;
                aluno.PontosFeitosDistribuicao = 0;

                meusModelos.atividadesFeitasDistribuicao = null;
                meusModelos.todasAtividadesDistribuicao = listaDeTodasAtividades;

                meusModelos.atividadesFeitasTendencia = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 2);
                meusModelos.todasAtividadesTendencia = atividadeREP.TodasAtividadesDeUmTopico(2);
            }
            else
            {
                if (valorComboTendencia == -1)
                {
                    List<AtividadeAluno> listaDeAtividadesFeitas = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 2);
                    List<Atividade> listaDeTodasAtividades = atividadeREP.TodasAtividadesDeUmTopico(2);

                    foreach (var feitas in listaDeAtividadesFeitas)

                    {
                        for (int i = 0; i < listaDeTodasAtividades.Count; i++)
                        {
                            if (listaDeTodasAtividades[i].IdAtividade == feitas.IdAtividade)
                            {
                                int index = listaDeTodasAtividades.IndexOf(listaDeTodasAtividades[i]);
                                listaDeTodasAtividades.RemoveAt(index);
                            }
                        }
                    }

                    double aux = 0;
                    foreach (var lista in listaDeTodasAtividades)
                    {
                        aux += lista.Nota;
                    }
                    aluno.PontosMedidasDeTendenciaCentral = aux;
                    aluno.PontosFeitosMedidasDeTendenciaCentral = 0;

                    meusModelos.atividadesFeitasTendencia = null;
                    meusModelos.todasAtividadesTendencia = listaDeTodasAtividades;

                    meusModelos.atividadesFeitasDistribuicao = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 1);
                    meusModelos.todasAtividadesDistribuicao = atividadeREP.TodasAtividadesDeUmTopico(1);
                }
                else
                {
                    if ((valorComboDistribuicao == 0 || valorComboTendencia == 0) || (valorComboDistribuicao == -100 && valorComboTendencia == -100))
                    {
                        List<Atividade> todasAtividadesDist = atividadeREP.TodasAtividadesDeUmTopico(1);
                        meusModelos.todasAtividadesDistribuicao = todasAtividadesDist;

                        List<AtividadeAluno> atividadesFeitasDist = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 1);
                        meusModelos.atividadesFeitasDistribuicao = atividadesFeitasDist;

                        List<Atividade> todasAtividadesTend = atividadeREP.TodasAtividadesDeUmTopico(2);
                        meusModelos.todasAtividadesTendencia = todasAtividadesTend;

                        List<AtividadeAluno> atividadesFeitasTend = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 2);
                        meusModelos.atividadesFeitasTendencia = atividadesFeitasTend;

                        double aux = 0;
                        foreach (var lista in atividadesFeitasDist)
                        {
                            aux += lista.Atividade.Nota;
                        }
                        aluno.PontosFeitosDistribuicao = aux;

                        double aux2 = 0;
                        foreach (var lista in todasAtividadesDist)
                        {
                            aux2 += lista.Nota;
                        }
                        aluno.PontosDistribuicao = aux2;

                        double aux3 = 0;
                        foreach (var lista in atividadesFeitasTend)
                        {
                            aux3 += lista.Atividade.Nota;
                        }
                        aluno.PontosFeitosMedidasDeTendenciaCentral = aux3;

                        double aux4 = 0;
                        foreach (var lista in todasAtividadesTend)
                        {
                            aux4 += lista.Nota;
                        }
                        aluno.PontosMedidasDeTendenciaCentral = aux4;
                    }
                    else
                    {
                        if (valorComboDistribuicao != 0 && valorComboDistribuicao != -100)
                        {
                            List<Atividade> todasAtividadesDist = atividadeREP.TodasAtividadesDeUmSubTopico(valorComboDistribuicao);
                            meusModelos.todasAtividadesDistribuicao = todasAtividadesDist;

                            List<AtividadeAluno> atividadesFeitasDist = atividadeAlunoREP.AtividadesFeitasDeUmSubTopico(aluno.IdAluno, valorComboDistribuicao);
                            meusModelos.atividadesFeitasDistribuicao = atividadesFeitasDist;

                            meusModelos.atividadesFeitasTendencia = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 2);
                            meusModelos.todasAtividadesTendencia = atividadeREP.TodasAtividadesDeUmTopico(2);

                            double aux = 0;
                            foreach (var lista in atividadesFeitasDist)
                            {
                                aux += lista.Atividade.Nota;
                            }
                            aluno.PontosFeitosDistribuicao = aux;

                            double aux2 = 0;
                            foreach (var lista in todasAtividadesDist)
                            {
                                aux2 += lista.Nota;
                            }
                            aluno.PontosDistribuicao = aux2;
                        }
                        else
                        {
                            if (valorComboTendencia != 0 && valorComboTendencia != -100)
                            {
                                List<Atividade> todasAtividadesTend = atividadeREP.TodasAtividadesDeUmSubTopico(valorComboTendencia);
                                meusModelos.todasAtividadesTendencia = todasAtividadesTend;
                                
                                List<AtividadeAluno> atividadesFeitasTend = atividadeAlunoREP.AtividadesFeitasDeUmSubTopico(aluno.IdAluno, valorComboTendencia);
                                meusModelos.atividadesFeitasTendencia = atividadesFeitasTend;

                                meusModelos.atividadesFeitasDistribuicao = atividadeAlunoREP.ListaAtividadesFeitasDeUmTopico(aluno.IdAluno, 1);
                                meusModelos.todasAtividadesDistribuicao = atividadeREP.TodasAtividadesDeUmTopico(1);

                                double aux = 0;
                                foreach (var lista in atividadesFeitasTend)
                                {
                                    aux += lista.Atividade.Nota;
                                }
                                aluno.PontosFeitosMedidasDeTendenciaCentral = aux;

                                double aux2 = 0;
                                foreach (var lista in todasAtividadesTend)
                                {
                                    aux2 += lista.Nota;
                                }
                                aluno.PontosMedidasDeTendenciaCentral = aux2;
                            }

                        }
                    }
                }

            }
        }
    }
}