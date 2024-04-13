using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PCDS2_Panaderia.Models
{
    public class PanesModel
    {
        public int idPanes { get; set; }

        public string? marcaP { get; set; }

        public string? nombreP { get; set; }

        public string? descripcionP { get; set; }

        public decimal costoP { get; set; }

        public int stockP { get; set; }

        public string? imagenP { get; set; }
    }
}
