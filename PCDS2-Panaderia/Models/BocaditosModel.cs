using Microsoft.Build.Framework;

namespace PCDS2_Panaderia.Models
{
    public class BocaditosModel
    {
        public int idBocaditos { get; set; }
        public string? marcaB { get; set; }
        public string? nombreB { get; set; }
        public string? descripcionB { get; set; }
        public decimal costoB { get; set; }
        public int stockB { get; set; }
        public string? imagenB { get; set; }
    }
}
