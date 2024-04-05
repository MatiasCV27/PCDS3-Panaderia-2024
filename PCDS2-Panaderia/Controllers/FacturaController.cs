using Microsoft.AspNetCore.Mvc;
using PCDS2_Panaderia.Data;
using PCDS2_Panaderia.Models;

namespace PCDS2_Panaderia.Controllers
{
    public class FacturaController : Controller
    {
        FacturaData _facturaData = new FacturaData();

        [HttpPost]
        public IActionResult CompraRealizada([FromBody] FacturaModel factura)
        {
            if (factura != null)
            {
                bool facturaGuardada = _facturaData.GuardarFactura(factura);
                if (facturaGuardada)
                {
                    return Ok("Factura guardada exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al guardar la factura en la base de datos");
                }
            }
            else
            {
                return BadRequest("Los datos de la factura no son válidos");
            }
        }
    }
}
