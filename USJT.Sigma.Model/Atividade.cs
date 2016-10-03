using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USJT.Sigma.Model
{
    public class Atividade
    {
        public int IdAtividade { get; set; }    
        public int IdAluno { get; set; }
        public int IdSubTopico { get; set; }
        public string NomeAtv { get; set; }
        public string DescricaoTitulo { get; set; }
        public string DescricaoSubTitulo { get; set; }
        public string DescricaoAtividade { get; set; }
        public string DescricaoPergunta { get; set; }
        public Double Nota { get; set; }
        public Double Progresso { get; set; }
        public string Resposta { get; set; }
        [Required]
        public List<string> ListaDeRespostas { get; set; }
    }
}
