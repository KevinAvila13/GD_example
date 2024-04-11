using GD_example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GD_example.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly GuatemaladigitalContext _context;

        public CategoriaController(GuatemaladigitalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categoria = _context.Categoria.Include(p => p.Productos);
            return View(await categoria.ToListAsync()); 
        }
    }
}
