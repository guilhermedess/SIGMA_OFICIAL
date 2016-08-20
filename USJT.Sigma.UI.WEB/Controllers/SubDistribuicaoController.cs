using System;
using System.Collections.Generic;
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

        public ActionResult IntroducaoDistribuicao(Aluno aluno)
        {
            try
            {
                aluno = (Aluno)Session["dadosAlunoLogado"];

                AtividadeREP atividadeREP = new AtividadeREP();

                List<Atividade> atividadesFeitas = atividadeREP.AtividadesFeitas(aluno.IdAluno);

                return View(atividadesFeitas);
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller: 'Ao carregar a página'");

                return RedirectToAction("Login", "Aluno");
            }
            
        }

        [HttpPost]
        public ActionResult IntroducaoDistribuicao(Aluno aluno, Atividade atividade)
        {
            try
            {
                AtividadeREP atividadeREP = new AtividadeREP();

                var nomeTopico = "Distribuicao";
                var nomeSubTopico = "IntroducaoADistribuicao";

                aluno = (Aluno)Session["dadosAlunoLogado"];

                if (atividade.Resposta == true)
                {
                    //consulta atividade pra ver se ja existe
                    if (atividadeREP.ExisteAtividade(aluno.IdAluno, atividade.NomeAtv))
                    {
                        TempData.Add("Mensagem", "Resposta Correta. Para relembrar esta atividade já foi feita em outra oportunidade.");

                        return RedirectToAction("IntroducaoDistribuicao", "SubDistribuicao");
                    }
                    else
                    {
                        int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                        atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, atividade.NomeAtv, atividade.Nota);

                        TempData.Add("Mensagem", "Resposta correta!");
                    }
                }
                else
                {
                    TempData.Add("Mensagem", "Resposta Errada!");
                }

                return RedirectToAction("IntroducaoDistribuicao", "SubDistribuicao");
            }
            catch (Exception)
            {
                TempData.Add("Mensagem", "Erro no Controller (POST): Entre novamente");

                return RedirectToAction("Login", "Aluno");
            }
            
        }

        public ActionResult PontosOuValores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PontosOuValores(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Pontos ou Valores";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvPontosOuValores";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade,0);
                }
            }
            return View();
        }

        public ActionResult ClassesOuIntervalos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClassesOuIntervalos(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Classes ou Intervalos";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvClassesOuIntevalos";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade, 0);
                }
            }
            return View();
        }

        public ActionResult Elementos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Elementos(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Elementos";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvElementos";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade, 0);
                }
            }
            return View();
        }

        public ActionResult FrequenciaRelativaPercentual()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FrequenciaRelativaPercentual(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Frequencia Relativa Percentual";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvFrequenciaRelativaPercentual";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade, 0);
                }
            }
            return View();
        }

        public ActionResult FrequenciaAcumuladaSimplesAbsoluta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FrequenciaAcumuladaSimplesAbsoluta(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Frequencia Acumulada Simples Absoluta";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvFrequenciaAcumuladaSimplesAbsoluta";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade, 0);
                }
            }
            return View();
        }

        public ActionResult FrequenciaAcumuladaRelativaPercentual()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FrequenciaAcumuladaRelativaPercentual(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Frequencia AcumuladaRelativa Percentual";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvFrequenciaAcumuladaRelativaPercentual";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade, 0);
                }
            }
            return View();
        }

        public ActionResult ApresentacaoDistribuicaoFrequencia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApresentacaoDistribuicaoFrequencia(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Apresentacao Distribuicao Frequencia";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvApresentacaoDistribuicaoFrequencia";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade, 0);
                }
            }
            return View();
        }

        public ActionResult ApresentacaoPontosOuValores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApresentacaoPontosOuValores(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Apresentacao Pontos ou Valores";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvApresentacaoPontosOuValores";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade, 0);
                }
            }
            return View();
        }

        public ActionResult ApresentacaoClassesOuIntervalos(Aluno aluno)
        {
            try
            {
                aluno = (Aluno)Session["dadosAlunoLogado"];

                AtividadeREP atividadeREP = new AtividadeREP();

                List<Atividade> atividadesFeitas = atividadeREP.AtividadesFeitas(aluno.IdAluno);

                return View(atividadesFeitas);
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
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Apresentacao Classes ou Intervalos";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvApresentacaoClassesOuIntervalos";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade, 0);
                }
            }
            return View();
        }

        public ActionResult rascunho()
        {
            return View();
        }
    }
}