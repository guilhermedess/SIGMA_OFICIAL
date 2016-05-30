using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USJT.Sigma.Model;
using USJT.Sigma.Repositorio;

namespace USJT.Sigma.UI.WEB.Controllers
{
    public class SubAmostragemController : Controller
    {
        SubTopicoREP subTopicoREP = new SubTopicoREP();
        AlunoREP alunoREP = new AlunoREP();

        public ActionResult ImpAmostragem()
        {
            var dadosAlunoLogado = Session["dadosAlunoLogado"];

            return View(dadosAlunoLogado);
        }

        [HttpPost]
        public ActionResult ImpAmostragem(Aluno aluno, Atividade atividade/*Aluno aluno, SubTopico subTopico, bool feito*/)
        {
            var nomeTopico = "Amostragem";
            var nomeSubTopico = "Importância da Amostragem";

            aluno = (Aluno) Session["dadosAlunoLogado"];

            var feito = true;
            
            if(atividade.Resposta == true)
                subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico, feito);

            return View();
        }

        public ActionResult Conceitos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Conceitos(SubTopico subTopico, bool feito)
        {
            feito = true;

            //subTopicoREP.checkSubTopico(feito);

            return View();
        }

        public ActionResult AleatoriaSimples()
        {
            return View();
        }

        public ActionResult AleatoriaEstratificada()
        {
            return View();
        }

        public ActionResult Conglomerado()
        {
            return View();
        }

        public ActionResult Sistematica()
        {
            return View();
        }

    }
}