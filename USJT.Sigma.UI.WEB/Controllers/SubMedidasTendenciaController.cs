using System;
using System.Collections.Generic;
using System.Dynamic;
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
        AtividadeREP atividadeREP = new AtividadeREP();
        AtividadeAlunoREP atividadeAlunoREP = new AtividadeAlunoREP();
        dynamic meusModelos = new ExpandoObject();

        public ActionResult ConferirRespotaRecebida(Atividade atividade, FormCollection form, string metodo, string controle)
        {
            Aluno aluno = (Aluno)Session["dadosAlunoLogado"];

            var respostaDoAluno = "";

            form.Remove("IdAtividade");

            if (form != null)
            {
                for (int i = 0; i < form.Count; i++)
                {
                    respostaDoAluno += form[i];
                }
            }

            if (respostaDoAluno.Equals(atividadeREP.RespostaExata(atividade.IdAtividade)))
            {
                //consulta atividade pra ver se ja existe
                if (atividadeAlunoREP.ExisteAtividadeFeita(aluno.IdAluno, atividade.IdAtividade))
                {
                    TempData.Add("Mensagem", "Resposta Correta. Atividade feita anteriormente.");

                    return RedirectToAction(metodo, controle);
                }
                else
                {
                    atividadeAlunoREP.AdicionaAtividadeAluno(aluno.IdAluno, atividade.IdAtividade);

                    TempData.Add("Mensagem", "Resposta correta!");
                }
            }
            else
            {
                TempData.Add("Mensagem", "Resposta Errada!");
            }

            return RedirectToAction(metodo, controle);
        }
        public ActionResult RenderizarView(int idSubTopico)
        {
            Aluno aluno = (Aluno)Session["dadosAlunoLogado"];

            meusModelos.atividades = atividadeREP.TodasAtividadesDeUmSubTopico(idSubTopico);
            meusModelos.atividadesFeitas = atividadeAlunoREP.AtividadesFeitas(aluno.IdAluno);

            return View(meusModelos);
        }
        public ActionResult IntroducaoMedidasTendencia()
        {
            try
            {
                return RenderizarView(9);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        [HttpPost]
        public ActionResult IntroducaoMedidasTendencia(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "IntroducaoMedidasTendencia", "SubMedidasTendencia");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }
        public ActionResult MediaSimples()
        {
            try
            {
                return RenderizarView(10);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        [HttpPost]
        public ActionResult MediaSimples(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "MediaSimples", "SubMedidasTendencia");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }
        public ActionResult MediaPonderada()
        {
            try
            {
                return RenderizarView(11);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        [HttpPost]
        public ActionResult MediaPonderada(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "MediaPonderada", "SubMedidasTendencia");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }
        public ActionResult Moda()
        {
            try
            {
                return RenderizarView(12);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        [HttpPost]
        public ActionResult Moda(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "Moda", "SubMedidasTendencia");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }
        public ActionResult Mediana()
        {
            try
            {
                return RenderizarView(13);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        [HttpPost]
        public ActionResult Mediana(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "Mediana", "SubMedidasTendencia");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }
    }
}