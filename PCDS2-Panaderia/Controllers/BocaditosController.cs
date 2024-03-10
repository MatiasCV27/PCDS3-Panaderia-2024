using PCDS2_Panaderia.Data;
using PCDS2_Panaderia.Models;   
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

namespace PCDS2_Panaderia.Controllers
{
    public class BocaditosController : Controller
    {
        BocaditosData _BocaData = new BocaditosData();

        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar(int id)
        {
            BocaditosModel boca = new BocaditosModel();
            if (boca == null)
            {
                return View(boca);
            }
            else
            {
                boca = _BocaData.ObtenerBocaditos(id);
                return View(boca);
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Listar()
        {
            var oBoca = _BocaData.ListarBocaditos();
            return Json(new { data = oBoca });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar(BocaditosModel oBoca)
        {
            if (!ModelState.IsValid)
                return View();

            if (oBoca.idBocaditos == 0) // Crea el registro
            {
                _BocaData.GuardarBocaditos(oBoca);
                return RedirectToAction(nameof(Guardar));
            }
            else
            {
                _BocaData.EditarBocaditos(oBoca);
                return RedirectToAction(nameof(Guardar), new { id = 0 });
            }
            return View();
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Eliminar(int idBoca)
        {
            var oBoca = _BocaData.ObtenerBocaditos(idBoca);
            if (oBoca == null)
            {
                return Json(new { Success = false, message = "Error al borrar el bocadito" });
            }
            _BocaData.EliminarBocaditos(oBoca.idBocaditos);
            return Json(new { Success = true, message = "Bocadito eliminado exitosamente" });
        }

        // User Vista:
        public IActionResult Ver_Bocaditos()
        {
            // La vista mostrara una Lista de Personas
            var oLista = _BocaData.ListarBocaditos();
            return View(oLista);
        }
    }
}
