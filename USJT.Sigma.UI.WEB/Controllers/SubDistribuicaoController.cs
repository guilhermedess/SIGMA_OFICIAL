using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USJT.Sigma.Model;
using USJT.Sigma.Repositorio;

namespace USJT.Sigma.UI.WEB.Controllers
{
    public class SubDistribuicaoController : Controller
    {
        SubTopicoREP subTopicoREP = new SubTopicoREP();

        public ActionResult ConceitosDeDistribuicao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConceitosDeDistribuicao(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Conceitos de Distribuicao";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvConceitosDeDistribuicao";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade);
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

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade);
                }
            }
            return View();
        }

        public ActionResult RegrasParaElaboracao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegrasParaElaboracao(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Regras para Elaboracao";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvRegrasParaElaboracao";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade);
                }
            }
            return View();
        }

        public ActionResult Graficos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Graficos(Aluno aluno, Atividade atividade)
        {
            AtividadeREP atividadeREP = new AtividadeREP();
            var nomeTopico = "Distribuicao";
            var nomeSubTopico = "Graficos";

            aluno = (Aluno)Session["dadosAlunoLogado"];

            if (atividade.Resposta == true)
            {
                var nomeAtividade = "AtvGraficos";

                //consulta atividade pra ver se ja existe
                if (atividadeREP.ExisteAtividade(aluno.IdAluno, nomeAtividade))
                {
                    return View();
                }
                else
                {
                    int idSubTopicoAdicionado = subTopicoREP.AdicionaSubTopico(aluno, nomeTopico, nomeSubTopico);

                    atividadeREP.AdicionaAtividade(aluno.IdAluno, idSubTopicoAdicionado, nomeAtividade);
                }
            }
            return View();
        }

    }
}