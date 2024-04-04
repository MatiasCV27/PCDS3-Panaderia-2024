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
        public IActionResult ListarUser()
        {
            // La vista mostrara una Lista de Personas
            var oLista = _userData.ListaUsuarios();
            return View(oLista);
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar()
        {
            // Metodo solo vuelve a la Vista
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Guardar(UsuariosModel oUser)
        {
            // Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _userData.GuardarUsuarios(oUser);

            if (respuesta)
                return RedirectToAction("ListarUser");
            else
                return View();
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Editar(int idUsuario)
        {
            var oUser = _userData.ObtenerUsuarios(idUsuario);
            return View(oUser);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Editar(UsuariosModel oUser)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _userData.EditarUsuarios(oUser);

            if (respuesta)
                return RedirectToAction("ListarUser");
            else
                return View();
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Eliminar(int idUsuario)
        {
            var oUser = _userData.ObtenerUsuarios(idUsuario);
            return View(oUser);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Eliminar(UsuariosModel oUser)
        {
            var respuesta = _userData.EliminarUsuarios(oUser.idUsuario);

            if (respuesta)
                return RedirectToAction("ListarUser");
            else
                return View();
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
        [HttpGet]
        [Route("Usuario/VerHistorial")]
        public IActionResult VerHistorial()
        {
            return View("~/Views/Usuarios/VerHistorial.cshtml");
        }

    }
}
