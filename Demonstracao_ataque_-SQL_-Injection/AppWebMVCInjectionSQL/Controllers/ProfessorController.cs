using AppWebMVCInjectionSQL.Data;
using AppWebMVCInjectionSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebMVCInjectionSQL.Controllers
{
    /// <summary>
    /// Controlador com métodos configurado de forma intencional e vulnerável para demonstrar um ataque de SQL Injection.
    /// </summary>
    public class ProfessorController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProfessorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Professor
        public IActionResult Index()
        {
            var query = "SELECT * FROM Professores";
            var professores = _context.Professores.FromSqlRaw(query).ToList();
            return View(professores);
        }



        /// <summary>
        ///  O método Details é vulnerável porque concatena diretamente o parâmetro id na consulta SQL.
        /// Um aluno mal-intencionado poderia inserir um valor como ('; DROP TABLE Professores;--) para deletar a tabela.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Professor/Details/5

        public IActionResult Details(int id)
        {
            // Código vulnerável a SQL Injection
            var query = "SELECT * FROM Professores WHERE Id = " + id;
            var professor = _context.Professores.FromSqlRaw(query).FirstOrDefault();
            return View(professor);
        }

        ////Possivél forma correta de evitar SQL Injection usando SQL parametrizado -----> Bug
        //public IActionResult Details(string id)
        //{
        //    var aluno = _context.Professores
        //    .FromSqlRaw("SELECT * FROM Professores WHERE id = @p0", id)
        //    .FirstOrDefault();
        //    return View(aluno);
        //}



        // GET: Professor/Create
        public IActionResult Create()
        {
            return View();
        }



        /// <summary>
        ///  O método Create é vulnerável porque concatena diretamente o parâmetro nome na consulta SQL.
        /// Um aluno mal-intencionado poderia inserir um valor como '; DROP TABLE Professores;-- para deletar a tabela.
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        // POST: Professor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Professor professor)
        {
            // Código vulnerável a SQL Injection
            var query = $"INSERT INTO Professores (Nome, Disciplina) VALUES ('{professor.Nome}', '{professor.Disciplina}')";
            _context.Database.ExecuteSqlRaw(query);
            return RedirectToAction(nameof(Index));
        }




        // GET: Professor/Edit/5
        public IActionResult Edit(int id)
        {
            var query = "SELECT * FROM Professores WHERE Id = " + id;
            var professor = _context.Professores.FromSqlRaw(query).FirstOrDefault();
            return View(professor);
        }

        /// <summary>
        ///  O método Edit é vulnerável porque concatena diretamente o parâmetro nome na consulta SQL.
        /// Um aluno mal-intencionado poderia inserir um valor como '; DROP TABLE Professores;-- para deletar a tabela.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professor"></param>
        /// <returns></returns>
        // POST: Professor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Professor professor)
        {
            // Código vulnerável a SQL Injection
            var query = $"UPDATE Professores SET Nome = '{professor.Nome}', Disciplina = '{professor.Disciplina}' WHERE Id = {id}";
            _context.Database.ExecuteSqlRaw(query);
            return RedirectToAction(nameof(Index));
        }




        // GET: Professor/Delete/5
        public IActionResult Delete(int id)
        {
            var query = "SELECT * FROM Professores WHERE Id = " + id;
            var professor = _context.Professores.FromSqlRaw(query).FirstOrDefault();
            return View(professor);
        }

        /// <summary>
        ///  O método DeleteConfirmed é vulnerável porque concatena diretamente o parâmetro nome na consulta SQL.
        /// Um aluno mal-intencionado poderia inserir um valor como '; DROP TABLE Professores;-- para deletar a tabela.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Código vulnerável a SQL Injection
            var query = "DELETE FROM Professores WHERE Id = " + id;
            _context.Database.ExecuteSqlRaw(query);
            return RedirectToAction(nameof(Index));
        }

    }
}
