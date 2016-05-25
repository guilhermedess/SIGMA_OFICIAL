using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USJT.Sigma.DataAccess;
using USJT.Sigma.Model;

namespace USJT.Sigma.Repositorio
{
    public class AlunoREP
    {
        public void Cadastrar(Aluno dadosTela)
        {
            using (var conexao = new SIGMAEntities())
            {
                var novoAluno = new TB_ALUNO();

                novoAluno.NOM_ALUNO = dadosTela.Nome;
                //IdTopico
                novoAluno.NUM_CPF = dadosTela.CPF;
                novoAluno.DES_EMAIL = dadosTela.Email;
                novoAluno.DAT_NASCIMENTO = dadosTela.DataNascimento;
                novoAluno.NOM_LOGIN = dadosTela.Usuário;
                novoAluno.DES_SENHA = dadosTela.Senha;

                conexao.TB_ALUNO.Add(novoAluno);
                conexao.SaveChanges();
            }
        }

        public void Editar(Aluno dadosTela)
        {
            using (var conexao = new SIGMAEntities())
            {
                var editarAluno = conexao.TB_ALUNO.Single(alunoModel => alunoModel.ID_ALUNO == dadosTela.IdAluno);

                editarAluno.NOM_ALUNO = dadosTela.Nome;
                editarAluno.DAT_NASCIMENTO = dadosTela.DataNascimento;
                editarAluno.DES_SENHA = dadosTela.Senha;

                conexao.SaveChanges();
            }
        }

        public Aluno buscaDadosAluno(Aluno dadosLogin)
        {
            using (var conexao = new SIGMAEntities())
            {
                var alunoRecuperado = conexao.TB_ALUNO.Single(modelAluno => modelAluno.NOM_LOGIN.Equals(dadosLogin.Usuário));

                dadosLogin.IdAluno = alunoRecuperado.ID_ALUNO;
                dadosLogin.Nome = alunoRecuperado.NOM_ALUNO;
                dadosLogin.CPF = alunoRecuperado.NUM_CPF;
                dadosLogin.DataNascimento = alunoRecuperado.DAT_NASCIMENTO;
                dadosLogin.Email = alunoRecuperado.DES_EMAIL;

                return dadosLogin;
            }
        }

        public void checkSubAluno(Aluno aluno, bool feito)
        {
            using (var conexao = new SIGMAEntities())
            {
                var alunoNovo = conexao.TB_ALUNO.Single(x => x.ID_ALUNO == 1);
                
                conexao.SaveChanges();
            }
        }

        public bool ValidarLogin(Aluno dadosLogin)
        {
            using (var conexao = new SIGMAEntities())
            {
                return conexao.TB_ALUNO.Any(x => x.NOM_LOGIN == dadosLogin.Usuário && x.DES_SENHA == dadosLogin.Senha);
            }
        }

    }
}
