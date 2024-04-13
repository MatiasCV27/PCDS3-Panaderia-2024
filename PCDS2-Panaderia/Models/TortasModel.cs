using Microsoft.Build.Framework;

namespace PCDS2_Panaderia.Models
{
    public class TortasModel
    {
        public int idTortas { get; set; }
        public string? marcaB { get; set; }
        public string? nombreT { get; set; }
        public string? descripcionT { get; set; }
        public decimal costoT { get; set; }
        public int stockT { get; set; }
        public string? imagenT { get; set; }
    }
}
