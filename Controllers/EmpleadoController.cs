using Microsoft.AspNetCore.Mvc;

using AppCrudNet8.Data;
using AppCrudNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrudNet8.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EmpleadoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> empleados = await _dbContext.Empleado.ToListAsync();

            return View(empleados);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Empleado pEmpleado)
        {
            await _dbContext.Empleado.AddAsync(pEmpleado);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _dbContext.Empleado.FirstAsync(e => e.Id == id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Empleado pEmpleado)
        {
            _dbContext.Empleado.Update(pEmpleado);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _dbContext.Empleado.FirstAsync(e => e.Id == id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(Empleado pEmpleado)
        {
            _dbContext.Empleado.Remove(pEmpleado);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
