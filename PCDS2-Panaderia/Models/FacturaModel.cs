using Microsoft.Build.Framework;

namespace PCDS2_Panaderia.Models
{
    public class FacturaModel
    {

        [Required]
        public int idFactura { get; set; }
        [Required]
        public string? usuario { get; set; }
        [Required]
        public int costo { get; set; }
        [Required]
        public string? descripcion { get; set; }
        [Required]
        public string? fecha { get; set; }

    }
}
