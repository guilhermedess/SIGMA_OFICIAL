using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USJT.Sigma.Model;
using USJT.Sigma.Repositorio;

namespace USJT.Sigma.UI.WEB.Controllers
{
    public class SubMedidasTendenciaController : Controller
    {
        SubTopicoREP subTopicoREP = new SubTopicoREP();
        public ActionResult IntroducaoMedidasTendencia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IntroducaoMedidasTendencia(Aluno aluno, Atividade atividade)
        {
            
            return View();
        }

        public ActionResult Media()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Media(Aluno aluno, Atividade atividade)
        {
            return View();
        }

        public ActionResult MediaSimples()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MediaSimples(Aluno aluno, Atividade atividade)
        {
            return View();
        }

        public ActionResult MediaPonderada()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MediaPonderada(Aluno aluno, Atividade atividade)
        {
            return View();
        }

        public ActionResult Moda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Moda(Aluno aluno, Atividade atividade)
        {
            return View();
        }

        public ActionResult Mediana()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Mediana(Aluno aluno, Atividade atividade)
        {
            return View();
        }
    }
}