using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USJT.Sigma.Model;
using USJT.Sigma.Repositorio;

namespace USJT.Sigma.UI.WEB.Controllers
{
    public class TopicoController : Controller
    {
        public ActionResult Topicos()
        {
            Aluno dadosAlunoLogado = (Aluno)Session["dadosAlunoLogado"];

            AlunoREP alunoREP = new AlunoREP();
            dadosAlunoLogado.ProgressoTotal = alunoREP.ProgressoTotal(dadosAlunoLogado.IdAluno);
            dadosAlunoLogado.ProgressoDistribuicao = alunoREP.ProgressoDistribuicao(dadosAlunoLogado.IdAluno);
            dadosAlunoLogado.ProgressoMedidasDeTendenciaCentral = alunoREP.ProgressoMedidasDeTendenciaCentral(dadosAlunoLogado.IdAluno);
            dadosAlunoLogado.ProgressoMedidasDeDispersao = alunoREP.ProgressoMedidasDeDispersao(dadosAlunoLogado.IdAluno);
            dadosAlunoLogado.ProgressoAmostragemEstimadores = alunoREP.ProgressoAmostragemEstimadores(dadosAlunoLogado.IdAluno);

            return View(dadosAlunoLogado);
        }
    }
}