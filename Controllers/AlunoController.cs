using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoCWebAPI.Models;

namespace PoCWebAPI.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private EscolaContext escola = new EscolaContext();

        [HttpGet]
        public Aluno[] MostrarAlunos()
        {
            return escola.Alunos.ToArray();
        }

        [HttpGet("{Id}")]
        public Aluno MostrarAlunoID(int Id)
        {
            Aluno resultado = new Aluno();

            foreach (Aluno aluno in escola.Alunos)
            {
                if (aluno.Id == Id)
                {
                    resultado = aluno;
                }
            }
            return resultado;
        }


        [HttpPost]
        public Aluno CadastrarAluno(Aluno novoAluno) 
        {
            escola.Alunos.Add(novoAluno);

            return novoAluno;
            escola.SaveChanges();
        }

        [HttpDelete("{Id}")]

        public Aluno RemoverAluno(int Id)
        {
            Aluno aluno = escola.Alunos.Find(Id);
            escola.Alunos.Remove(aluno);
            escola.SaveChanges();
            return aluno;
        }
    }
}