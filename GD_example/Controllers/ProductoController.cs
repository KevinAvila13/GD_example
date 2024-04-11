using GD_example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GD_example.Controllers
{
    public class ProductoController : Controller
    {
        private readonly GuatemaladigitalContext _context;

        public ProductoController(GuatemaladigitalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {


            return View(await _context.Productos.ToListAsync());
        }
    }
}
