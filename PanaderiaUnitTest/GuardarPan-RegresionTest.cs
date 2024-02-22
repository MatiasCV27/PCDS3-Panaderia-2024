using PCDS2_Panaderia.Data;
using PCDS2_Panaderia.Models;

namespace PanaderiaUnitTest
{
    public class GuardarPan_RegresionTest
    {
        [Fact]
        public void GuardarPanes_RegresíonTest()
        {
            // Arrange
            var guardar = new PanesData();
            var panesModel = new PanesModel
            {
                marcaP = "Artesanal",
                nombreP = "Pan francés",
                descripcionP = "Pan de orige frances, crocante y delicioso",
                costoP = 1.20m,
                fechaCreacionP = DateTime.Now,
                fechaVencimiP = DateTime.Now.AddDays(7),
                stockP = 20,
                imagenP = "notfoundbread.png"
            };

            // Act
            bool result = guardar.GuardarPanes(panesModel);

            // Assert
            Assert.True(result);
        }
    }
}
