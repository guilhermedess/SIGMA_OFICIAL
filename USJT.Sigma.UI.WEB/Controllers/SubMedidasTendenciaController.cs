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
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "MedidasDeTendenciaCentral";
            var nomeSubTopico = "Introducao a Tendência";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvIntroducaoTendencia";

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

        public ActionResult Media()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Media(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "MedidasDeTendenciaCentral";
            var nomeSubTopico = "Média";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvMedia";

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

        public ActionResult MediaSimples()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MediaSimples(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "MedidasDeTendenciaCentral";
            var nomeSubTopico = "MediaSimples";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvMediaSimples";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    TempData.Add("Mensagem", "Resposta Correta. Para relembrar esta atividade já foi feita em outra oportunidade.");

                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade, 0);

                    TempData.Add("Mensagem", "Resposta correta!");
                }
            }
            else
            {
                TempData.Add("Mensagem", "Resposta Errada!");
            }
            return View();
        }

        public ActionResult MediaPonderada()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MediaPonderada(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "MedidasDeTendenciaCentral";
            var nomeSubTopico = "MediaPonderada";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvMediaPonderada";

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

        public ActionResult Moda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Moda(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "MedidasDeTendenciaCentral";
            var nomeSubTopico = "Moda";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvIModa";

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

        public ActionResult Mediana()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Mediana(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "MedidasDeTendenciaCentral";
            var nomeSubTopico = "Mediana";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvMediana";

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
    }
}