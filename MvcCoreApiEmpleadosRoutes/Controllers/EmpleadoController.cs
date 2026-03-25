using Microsoft.AspNetCore.Mvc;
using MvcCoreApiEmpleadosRoutes.Services;
using NugetApiModels.Models;

namespace MvcCoreApiEmpleadosRoutes.Controllers
{
    public class EmpleadoController : Controller
    {
        private ServiceEmpleados service;

        public EmpleadoController(ServiceEmpleados service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<string> oficios = await this.service.GetOficioAsync();
            List<Empleado> empleados = await this.service.GetEmpleadoAsync();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string oficio)
        {
            List<string> oficios = await this.service.GetOficioAsync();
            List<Empleado> empleados = await this.service.GetEmpleadoOficioAsync(oficio);
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }

        public async Task<IActionResult> Details(int id)
        {
            Empleado emp = await this.service.FindEmpleadoAsync(id);
            return View(emp);
        }
    }
}
