using PCDS2_Panaderia.Models;
using System.Data.SqlClient;
using System.Data;

namespace PCDS2_Panaderia.Data
{
    public class FacturaData
    {
        public List<FacturaModel> ListarFactura()
        {
            var oLista = new List<FacturaModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getCadenaSQL()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarFactura", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new FacturaModel()
                        {
                            idFactura = Convert.ToInt32(dr["idFactura"]),
                            usuario = dr["usuario"].ToString(),
                            costo = Convert.ToDecimal(dr["costo"]),
                            descripcion = dr["descripcion"].ToString(),
                            fecha = dr["fecha"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public bool GuardarFactura(FacturaModel oFactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarFactura", con);
                    cmd.Parameters.AddWithValue("usuario", oFactura.usuario);
                    cmd.Parameters.AddWithValue("costo", oFactura.costo);
                    cmd.Parameters.AddWithValue("descripcion", oFactura.descripcion);
                    cmd.Parameters.AddWithValue("fecha", oFactura.fecha);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }
            return rpta;
        }
    }
}
