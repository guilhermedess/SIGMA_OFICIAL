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
                         "4 - Elementos", "4.1 - Freq. relativa ou percentual", "4.2 - Acum. simples ou absoluta", "4.3 - Acum. relativa ou percentual",
                         "5 - Apresentação de distribuição", "5.1 - Freq. por pontos ou valores", "5.2 - Freq. por classes ou intervalos"};

            ViewBag.Opcoes = new SelectList(opcoes);
        }

        public ActionResult Progresso(Aluno aluno)
        {
            try
            {
                CarregarComboDistribuicao();

                AtividadeREP atividadeREP = new AtividadeREP();

                dynamic meusModelos = new ExpandoObject();

                aluno = (Aluno)Session["dadosAlunoLogado"];
                meusModelos.Aluno = (Aluno)Session["dadosAlunoLogado"];

                //meusModelos.AtividadesFeitas = (List<Atividade>)atividadeREP.AtividadesFeitas(aluno.IdAluno); ;
                meusModelos.todas = "todas";

                return View(meusModelos);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }

        [HttpPost]
        public ActionResult Progresso(Aluno aluno, string comboDistribuicao)
        {
            try
            {
                var procurarAtv = ValidarComboDistribuicao(comboDistribuicao);
                
                AtividadeREP atividadeREP = new AtividadeREP();
                dynamic meusModelos = new ExpandoObject();

                aluno = (Aluno)Session["dadosAlunoLogado"];
                meusModelos.Aluno = (Aluno)Session["dadosAlunoLogado"];

                meusModelos.AtividadesFeitas = null;
                meusModelos.todas = procurarAtv;

                if (procurarAtv == null || procurarAtv == "")
                {
                    TempData.Add("Mensagem", "Opa, não pode!");

                    CarregarComboDistribuicao();

                    //meusModelos.AtividadesFeitas = (List<Atividade>)atividadeREP.AtividadesFeitas(aluno.IdAluno);
                    meusModelos.todas = "todas";

                    return View(meusModelos);
                }
                else
                {
                    if (procurarAtv.Equals("todas"))
                    {
                        //meusModelos.AtividadesFeitas = (List<Atividade>)atividadeREP.AtividadesFeitas(aluno.IdAluno);
                        meusModelos.todas = "todas";
                    }
                    else
                    {
                        if (procurarAtv.Equals("todasPendentes"))
                        {
                            //meusModelos.AtividadesFeitas = (List<Atividade>)atividadeREP.AtividadesFeitas(aluno.IdAluno);
                        }
                        else
                        {
                            meusModelos.AtividadesFeitas = (List<Atividade>)atividadeREP.AtividadesFeitasDeUmSubTopico(aluno.IdAluno, procurarAtv);
                        }                        
                    }
                }
                //verificar aqui
                CarregarComboDistribuicao();

                return View(meusModelos);

            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }

        public string ValidarComboDistribuicao(string comboDistribuicao)
        {
            string procurarAtv = null;

            if (comboDistribuicao.Equals("O - Todas"))
            {
                procurarAtv = "todas";
            }
            else
            {
                if (comboDistribuicao.Equals("X - Todas Pendentes"))
                {
                    procurarAtv = "todasPendentes";
                }
                else
                {
                    if (comboDistribuicao.Equals("1 - Introdução e Conceitos"))
                    {
                        procurarAtv = "IntroducaoADistribuicao";
                    }
                    else
                    {
                        if (comboDistribuicao.Equals("2 - Dist. Pontos ou valores"))
                        {
                            procurarAtv = "PontosValores";
                        }
                        else
                        {
                            if (comboDistribuicao.Equals("3 - Classes ou intervalos"))
                            {
                                procurarAtv = "ClassesIntervalos";
                            }
                            else
                            {
                                if (comboDistribuicao.Equals("4 - Elementos"))
                                {
                                    procurarAtv = "Elementos";
                                }
                                else
                                {
                                    if (comboDistribuicao.Equals("4.1 - Freq. relativa ou percentual"))
                                    {
                                        procurarAtv = "RelativaPercentual";
                                    }
                                    else
                                    {
                                        if (comboDistribuicao.Equals("4.2 - Acum. simples ou absoluta"))
                                        {
                                            procurarAtv = "AcumuladaSimplesOuAbsoluta";
                                        }
                                        else
                                        {
                                            if (comboDistribuicao.Equals("4.3 - Acum. relativa ou percentual"))
                                            {
                                                procurarAtv = "AcumuladaRelativaOuPercentual";
                                            }
                                            else
                                            {
                                                if (comboDistribuicao.Equals("5 - Apresentação de distribuição"))
                                                {
                                                    procurarAtv = "ApresentacaoDeDistribuicaoFreq";
                                                }
                                                else
                                                {
                                                    if (comboDistribuicao.Equals("5.1 - Freq. por pontos ou valores"))
                                                    {
                                                        procurarAtv = "FrequenciaPontosOuValores";
                                                    }
                                                    else
                                                    {
                                                        if (comboDistribuicao.Equals("5.2 - Freq. por classes ou intervalos"))
                                                        {
                                                            procurarAtv = "FrequenciaClassesOuIntervalos";
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
                }

            }

            return procurarAtv;
        }
    }
}