using Microsoft.AspNetCore.Mvc;
using PCDS2_Panaderia.Models;
using PCDS2_Panaderia.Data;

using Microsoft.AspNetCore.Authorization;

namespace PCDS2_Panaderia.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosData _userData = new UsuariosData();

        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar(int id)
        {
            UsuariosModel user = new UsuariosModel();
            if (id == null)
            {
                return View(user);
            }
            else
            {
                user = _userData.ObtenerUsuarios(id);
                return View(user);
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult ListarUser()
        {
            var oLista = _userData.ListaUsuarios();
            return Json(new { data = oLista });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar(UsuariosModel oUser)
        {
            if (!ModelState.IsValid)
                return View();

            if (oUser.idUsuario == 0) // Crea el registro
            {
                _userData.GuardarUsuarios(oUser);
                return RedirectToAction(nameof(Guardar));
            }
            else
            {
                _userData.EditarUsuarios(oUser);
                return RedirectToAction(nameof(Guardar), new { id = 0 });
            }
            return View();
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Eliminar(int idUsuario)
        {
            var oUser = _userData.ObtenerUsuarios(idUsuario);
            if (oUser == null)
            {
                return Json(new { Success = false, message = "Error al borrar el pan" });
            }
            _userData.EliminarUsuarios(oUser.idUsuario);
            return Json(new { Success = true, message = "Pan eliminado exitosamente" });
        }

        // Ver Compras
        public IActionResult VerCompras()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            // Metodo solo vuelve a la Vista
            return View();
        }

        // Ver Historial
        FacturaData _facturaData = new FacturaData();

		[HttpGet]
		[Route("Usuario/VerHistorial")]
		public IActionResult VerHistorial()
        {
            var oLista = _facturaData.ListarFactura();
            return View(oLista);
        }

    }
}
