using Microsoft.AspNetCore.Mvc;
using PCDS2_Panaderia.Data;
using PCDS2_Panaderia.Models;

using Microsoft.AspNetCore.Authorization;

namespace PCDS2_Panaderia.Controllers
{
    public class TortasController : Controller
    {
        TortasData _TorData = new TortasData();

        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar(int id)
        {
            TortasModel torta = new TortasModel();
            if (id == null)
            {
                return View(torta);
            }
            else
            {
                torta = _TorData.ObtenerTortas(id);
                return View(torta);
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Listar()
        {
            var oLista = _TorData.ListarTortas();
            return Json(new { data = oLista });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar(TortasModel otorta)
        {
            if (!ModelState.IsValid)
                return View();

            if (otorta.idTortas == 0) // Crea el registro
            {
                _TorData.GuardarTortas(otorta);
                return RedirectToAction(nameof(Guardar));
            }
            else
            {
                _TorData.EditarTortas(otorta);
                return RedirectToAction(nameof(Guardar), new { id = 0 });
            }
            return View();
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Eliminar(int idTortas)
        {
            var oTorta = _TorData.ObtenerTortas(idTortas);
            if (oTorta == null)
            {
                return Json(new { Success = false, message = "Error al borrar el pastel" });
            }
            _TorData.EliminarTortas(oTorta.idTortas);
            return Json(new { Success = true, message = "Pastel eliminado exitosamente" });
        }

        // User Vista:
        public IActionResult Ver_Pasteles()
        {
            // La vista mostrara una Lista de Personas
            var oLista = _TorData.ListarTortas();
            return View(oLista);
        }
    }
}
