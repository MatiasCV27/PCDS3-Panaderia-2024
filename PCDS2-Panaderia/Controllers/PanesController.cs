using Microsoft.AspNetCore.Mvc;
using PCDS2_Panaderia.Data;
using PCDS2_Panaderia.Models;

using Microsoft.AspNetCore.Authorization;
using TechTalk.SpecFlow.CommonModels;

namespace PCDS2_Panaderia.Controllers
{
    public class PanesController : Controller
    {
        PanesData _PanData = new PanesData();

        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar(int id)
        {
            PanesModel pan = new PanesModel();
            if(id == null) {
                return View(pan);
            } else {
                pan = _PanData.ObtenerPanes(id);
                return View(pan);  
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Listar()
        {
            var oLista = _PanData.ListarPanes();
            return Json(new { data = oLista });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar(PanesModel oPan)
        {
            if (!ModelState.IsValid)
                return View();

            if (oPan.idPanes == 0) // Crea el registro
            {
                _PanData.GuardarPanes(oPan);
                return RedirectToAction(nameof(Guardar));
            }
            else
            {
                _PanData.EditarPanes(oPan);
                return RedirectToAction(nameof(Guardar), new {id = 0});
            }
            return View();
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Eliminar(int idPanes)
        {
            var oPan = _PanData.ObtenerPanes(idPanes);
            if (oPan == null)
            {
                return Json(new {Success = false, message = "Error al borrar el pan"});
            }
            _PanData.EliminarPanes(oPan.idPanes);
            return Json(new { Success = true , message = "Pan eliminado exitosamente"});
        }

        // User Vista:
        public IActionResult Ver_Panes()
        {
            var oLista = _PanData.ListarPanes();
            return View(oLista);
        }

    }
}
