using AppWebMVCInjectionSQL.Data;
using AppWebMVCInjectionSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebMVCInjectionSQL.Controllers
{
    /// <summary>
    /// Controlador com métodos configurado de forma intencional e vulnerável para demonstrar um ataque de SQL Injection.
    /// </summary>
    public class AlunoController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AlunoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aluno
        public IActionResult Index()
        {
            var query = "SELECT * FROM Alunos";
            var alunos = _context.Alunos.FromSqlRaw(query).ToList();
            return View(alunos);
        }

        /// <summary>
        ///  O método Details é vulnerável porque concatena diretamente o parâmetro id na consulta SQL.
        /// Uma pessoa mal-intencionada poderia inserir um valor como '; DROP TABLE Alunos;-- para deletar a tabela. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Aluno/Details/5
        public IActionResult Details(int id)
        {
            // Código vulnerável a SQL Injection
            var query = "SELECT * FROM Alunos WHERE Id = " + id;
            var aluno = _context.Alunos.FromSqlRaw(query).FirstOrDefault();
            return View(aluno);
        }

        ////Possivél forma correta de evitar SQL Injection usando SQL parametrizado -----> Bug
        //public IActionResult Details(string id)
        //{
        //    var aluno = _context.Alunos
        //    .FromSqlRaw("SELECT * FROM Professores WHERE id = @p0", id)
        //    .FirstOrDefault();
        //    return View(aluno);
        //}




        // GET: Aluno/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///  O método Create é vulnerável porque concatena diretamente o parâmetro nome na consulta SQL.
        /// Um aluno mal-intencionado poderia inserir um valor como '; DROP TABLE Alunos;-- para deletar a tabela.
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno aluno)
        {
            // Código vulnerável a SQL Injection
            var query = $"INSERT INTO Alunos (Nome, Idade) VALUES ('{aluno.Nome}', {aluno.Idade})";
            _context.Database.ExecuteSqlRaw(query);
            return RedirectToAction(nameof(Index));
        }


        // GET: Aluno/Edit/5
        public IActionResult Edit(int id)
        {
            var query = "SELECT * FROM Alunos WHERE Id = " + id;
            var aluno = _context.Alunos.FromSqlRaw(query).FirstOrDefault();
            return View(aluno);
        }


        /// <summary>
        ///  O método Edit é vulnerável porque concatena diretamente o parâmetro nome na consulta SQL.
        /// Um aluno mal-intencionado poderia inserir um valor como '; DROP TABLE Alunos;-- para deletar a tabela.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="aluno"></param>
        /// <returns></returns>
        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Aluno aluno)
        {
            // Código vulnerável a SQL Injection
            var query = $"UPDATE Alunos SET Nome = '{aluno.Nome}', Idade = {aluno.Idade} WHERE Id = {id}";
            _context.Database.ExecuteSqlRaw(query);
            return RedirectToAction(nameof(Index));
        }

        // GET: Aluno/Delete/5
        public IActionResult Delete(int id)
        {
            var query = "SELECT * FROM Alunos WHERE Id = " + id;
            var aluno = _context.Alunos.FromSqlRaw(query).FirstOrDefault();
            return View(aluno);
        }


        /// <summary>
        ///  O método DeleteConfirmed é vulnerável porque concatena diretamente o parâmetro id na consulta SQL.
        /// Um aluno mal-intencionado poderia inserir um valor como '; DROP TABLE Alunos;-- para deletar a tabela.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Código vulnerável a SQL Injection
            var query = "DELETE FROM Alunos WHERE Id = " + id;
            _context.Database.ExecuteSqlRaw(query);
            return RedirectToAction(nameof(Index));
        }

    }
}
