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

        public ActionResult ConferirRespotaRecebida(Atividade atividade, string metodo, string controle)
        {
            Aluno aluno = (Aluno)Session["dadosAlunoLogado"];

            var respostaDoAluno = "";

            foreach (var respostas in atividade.ListaDeRespostas)
            {
                respostaDoAluno += respostas;
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
        public ActionResult IntroducaoDistribuicao(Atividade atividade)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, "IntroducaoDistribuicao", "SubDistribuicao");
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
        public ActionResult PontosOuValores(Aluno aluno, Atividade atividade)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, "PontosOuValores", "SubDistribuicao");
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
        public ActionResult ClassesOuIntervalos(Aluno aluno, Atividade atividade)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, "ClassesOuIntervalos", "SubDistribuicao");
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
        public ActionResult FrequenciaRelativaPercentual(Aluno aluno, Atividade atividade)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, "FrequenciaRelativaPercentual", "SubDistribuicao");
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
        public ActionResult FrequenciaAcumuladaSimplesAbsoluta(Aluno aluno, Atividade atividade)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, "FrequenciaAcumuladaSimplesAbsoluta", "SubDistribuicao");
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
        public ActionResult FrequenciaAcumuladaRelativaPercentual(Aluno aluno, Atividade atividade)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, "FrequenciaAcumuladaRelativaPercentual", "SubDistribuicao");
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
        public ActionResult ApresentacaoPontosOuValores(Aluno aluno, Atividade atividade)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, "ApresentacaoPontosOuValores", "SubDistribuicao");
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
        public ActionResult ApresentacaoClassesOuIntervalos(Aluno aluno, Atividade atividade)
        {
            try
            {
                return ConferirRespotaRecebida(atividade, "ApresentacaoClassesOuIntervalos", "SubDistribuicao");
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