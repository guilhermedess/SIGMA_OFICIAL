using Microsoft.Reporting.WebForms;
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


            AtividadeREP atividadeREP = new AtividadeREP();
            var x = atividadeREP.TotalDistribuicao();

            //dadosAlunoLogado.ProgressoTotal = alunoREP.ProgressoTotal(dadosAlunoLogado.IdAluno);
            //dadosAlunoLogado.ProgressoDistribuicao = alunoREP.ProgressoDistribuicao(dadosAlunoLogado.IdAluno);
            //dadosAlunoLogado.ProgressoMedidasDeTendenciaCentral = alunoREP.ProgressoMedidasDeTendenciaCentral(dadosAlunoLogado.IdAluno);
            //dadosAlunoLogado.ProgressoMedidasDeDispersao = alunoREP.ProgressoMedidasDeDispersao(dadosAlunoLogado.IdAluno);
            //dadosAlunoLogado.ProgressoAmostragemEstimadores = alunoREP.ProgressoAmostragemEstimadores(dadosAlunoLogado.IdAluno);

            return View(dadosAlunoLogado);
        }

        //ActionResult para gerar(.pdf) relatório com Report Viewer em ASP.NET MVC
        [HttpPost]
        public ActionResult GeraCertificado()
        {
            //responsavel por visualizar o relatorio
            ReportViewer reportViewer = new ReportViewer();
            //modo de processamento
            reportViewer.ProcessingMode = ProcessingMode.Local;
            //caminho do relatorio .rdlc
            reportViewer.LocalReport.ReportEmbeddedResource =
                "USJT.Sigma.UI.WEB.RepCertificado.rdlc";
            //add paramentros do relatorio
            //add uma lista de parametros para o relatorio
            List<ReportParameter> listReportParameter = new List<ReportParameter>();
            //recupera o nome
            string nome = "Dênis de Figueiredo Pessoa";
            //string data = "São Paulo " + DateTime.Now.ToString("dd - MM - yyyy");
            //add na lista
            listReportParameter.Add(new ReportParameter("Nome", nome));
            //listReportParameter.Add(new ReportParameter("Data", data));

            reportViewer.LocalReport.SetParameters(listReportParameter);

            //montar a renderização e exibição do relatorio
            //var ax para consultar informações
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            //renderizar pdf
            byte[] bytePDF = reportViewer.LocalReport.Render(
                "Pdf", null, out mimeType, out encoding,
                out extension, out streamids, out warnings
                );

            return File(bytePDF, mimeType);
        }
    }
    
}