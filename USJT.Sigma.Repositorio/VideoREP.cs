using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USJT.Sigma.DataAccess;
using USJT.Sigma.Model;

namespace USJT.Sigma.Repositorio
{
    public class VideoREP
    {
        public string BuscaVideoPorSubTopico(int idSubTopico, string nomeVideo)
        {
            using (var conexao = new SIGMAEntities())
            {
                var videoRecuperado = conexao.TB_VIDEO.Single(modelVideo => modelVideo.ID_SUBTOPICO == idSubTopico && modelVideo.NOM_VIDEO.Equals(nomeVideo));

                return videoRecuperado.DES_URL;
            }
        }
        public string BuscaVideoPorIdAtividade(int idAtividade, string nomeVideo)
        {
            using (var conexao = new SIGMAEntities())
            {
                var videoRecuperado = conexao.TB_VIDEO.Single(modelVideo => modelVideo.ID_ATIVIDADE == idAtividade && modelVideo.NOM_VIDEO.Equals(nomeVideo));

                return videoRecuperado.DES_URL;
            }
        }

    }
}
