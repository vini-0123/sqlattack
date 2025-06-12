using AppWebMVCInjectionSQL.Data;
using AppWebMVCInjectionSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebMVCInjectionSQL.Controllers
{
    /// <summary>
    /// Controlador com métodos configurado de forma intencional e vulnerável para demonstrar um ataque de SQL Injection.
    /// </summary>
    public class AvanAlunoController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AvanAlunoController(ApplicationDbContext context)
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

        // GET: Aluno/Details/5
        public IActionResult Details(int id)
        {
            // Código vulnerável a SQL Injection
            var query = "SELECT * FROM Alunos WHERE Id = " + id;
            var aluno = _context.Alunos.FromSqlRaw(query).FirstOrDefault();
            return View(aluno);
        }

        // GET: Aluno/Create
        public IActionResult Create()
        {
            return View();
        }

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

