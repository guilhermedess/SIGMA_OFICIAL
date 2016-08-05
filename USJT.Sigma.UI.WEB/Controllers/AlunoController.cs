using System;
using System.Collections.Generic;
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
    }
}