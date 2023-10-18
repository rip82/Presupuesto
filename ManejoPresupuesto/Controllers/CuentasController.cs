using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejoPresupuesto.Controllers
{
    public class CuentasController: Controller
    {
        private readonly IRepositorioTiposCuentas repositorioTiposCuentas;

        public CuentasController(IRepositorioTiposCuentas repositorioTiposCuentas, 
            IServicioUsuarios ServicioUsuarios)
        {
            this.repositorioTiposCuentas = repositorioTiposCuentas;
            this.ServicioUsuarios = ServicioUsuarios;
        }

        public IServicioUsuarios ServicioUsuarios { get; }

        public async Task<IActionResult> Crear()
        {
            var usuarioId = ServicioUsuarios.ObtenerUsuarioId();
            var tiposCuentas = await repositorioTiposCuentas.Obtener(usuarioId);
            var modelo = new CuentaCreacionViewModel();
            modelo.TiposCuentas = tiposCuentas.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
            return View(modelo);
        }
    }
}
