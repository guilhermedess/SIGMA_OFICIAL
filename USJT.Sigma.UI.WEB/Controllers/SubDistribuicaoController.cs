using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using USJT.Sigma.Model;
using USJT.Sigma.Repositorio;

namespace USJT.Sigma.UI.WEB.Controllers
{
    public class SubDistribuicaoController : Controller
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
        public ActionResult IntroducaoDistribuicao()
        {
            try
            {
                return RenderizarView(1);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }
        [HttpPost]
        public ActionResult IntroducaoDistribuicao(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "IntroducaoDistribuicao", "SubDistribuicao");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }

        public ActionResult PontosOuValores()
        {
            try
            {
                return RenderizarView(2);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }

        [HttpPost]
        public ActionResult PontosOuValores(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "PontosOuValores", "SubDistribuicao");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }

        public ActionResult ClassesOuIntervalos()
        {
            try
            {
                return RenderizarView(3);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }

        [HttpPost]
        public ActionResult ClassesOuIntervalos(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "ClassesOuIntervalos", "SubDistribuicao");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }

        public ActionResult FrequenciaRelativaPercentual()
        {
            try
            {
                return RenderizarView(4);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }

        [HttpPost]
        public ActionResult FrequenciaRelativaPercentual(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "FrequenciaRelativaPercentual", "SubDistribuicao");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }

        public ActionResult FrequenciaAcumuladaSimplesAbsoluta()
        {
            try
            {
                return RenderizarView(5);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }

        [HttpPost]
        public ActionResult FrequenciaAcumuladaSimplesAbsoluta(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "FrequenciaAcumuladaSimplesAbsoluta", "SubDistribuicao");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }

        public ActionResult FrequenciaAcumuladaRelativaPercentual()
        {
            try
            {
                return RenderizarView(6);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }

        [HttpPost]
        public ActionResult FrequenciaAcumuladaRelativaPercentual(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "FrequenciaAcumuladaRelativaPercentual", "SubDistribuicao");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }

        public ActionResult ApresentacaoPontosOuValores()
        {
            try
            {
                return RenderizarView(7);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }

        [HttpPost]
        public ActionResult ApresentacaoPontosOuValores(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "ApresentacaoPontosOuValores", "SubDistribuicao");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }

        public ActionResult ApresentacaoClassesOuIntervalos()
        {
            try
            {
                return RenderizarView(8);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
        }

        [HttpPost]
        public ActionResult ApresentacaoClassesOuIntervalos(Atividade atividade, FormCollection form)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, form, "ApresentacaoClassesOuIntervalos", "SubDistribuicao");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
        }

        public ActionResult rascunho()
        {
            return View();
        }
    }
}