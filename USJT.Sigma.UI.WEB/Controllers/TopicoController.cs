using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USJT.Sigma.UI.WEB.Controllers
{
    public class TopicoController : Controller
    {
        public ActionResult Topicos()
        {
            var dadosAlunoLogado = Session["dadosAlunoLogado"];
    
            return View(dadosAlunoLogado);
        }
    }
}