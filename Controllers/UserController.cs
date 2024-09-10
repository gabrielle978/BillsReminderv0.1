using BillsReminder.Database;
using BillsReminder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillsReminder.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> DetailsUser(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: /Users/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Users/Login
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(string email, string senha)
        {
            // Verifica se o usuário existe no banco de dados
            var usuario = _context.Users.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                // Usuário encontrado, redireciona para a página inicial
                return RedirectToAction("Index", "User");
            }
            else
            {
                // Usuário não encontrado, retorna a view de login com uma mensagem
                ViewBag.ErrorMessage = "Usuário não encontrado. Por favor, registre-se.";
                return View();
            }
        }
        // GET: /Users/Create
        public IActionResult CreateUser()
        {
            return View();
        }

        // POST: /Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login"); // Redireciona para a lista de usuários após a criação
            }
            return View(user);
        }

        // GET: /Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

    }
}

