using CN_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace CapaDatos
{
    public class CD_Adoptante
    {
        public List<Adoptantes> Listar()
        {
            List<Adoptantes> lista = new List<Adoptantes>();

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from AdoptanteId, Nombre, Apellido, Direccion, Correo from Adoptante";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.CommandType = CommandType.Text;

                    cn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(
                                new Adoptantes
                                {
                                    Id = Convert.ToInt32(rd["Id"]),
                                    Nombre = rd["Nombre"].ToString(),
                                    Apellido = rd["Apellido"].ToString(),
                                    Direccion = rd["Direccion"].ToString(),
                                    Correo = rd["Correo"].ToString()

                                });
                        }
                    }

                }
            }
            catch (Exception)
            {

                lista = new List<Adoptantes>();
            }

            return lista;
          
        }
    }
}
