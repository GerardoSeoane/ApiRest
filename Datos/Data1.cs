using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Data1
    {
        private SqlConnection Conexion = new SqlConnection("Server=.;Database=Curso;User id= sa; Password=12345");

        public void ConexionBD() 
        {
            Conexion.Open();
        }
        public void Desconexion()
        {
            Conexion.Close();
        }

        public DataTable Mostar()
        {
            try
            {
                ConexionBD();
                DataTable Tabla = new DataTable();
                SqlCommand Comando = new SqlCommand("SP_Mostrar",Conexion);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Datos = new SqlDataAdapter(Comando);
                Datos.Fill(Tabla);
                Desconexion();
                return Tabla;
            }
            catch (Exception error)
            {
                return new DataTable();
            }
        } 

        public int Insertar(string Nombre,string Escuderia,string Pais)
        {
            int FilasAfectadas = 0;
            try
            {
                ConexionBD();
                SqlCommand Comando = new SqlCommand("SP_Insertar", Conexion);
                Comando.CommandType= CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Nombre", Nombre);
                Comando.Parameters.AddWithValue("@Escuderia", Escuderia);
                Comando.Parameters.AddWithValue("@Pais", Pais);
                FilasAfectadas = Comando.ExecuteNonQuery();
                Desconexion();
                return FilasAfectadas;
            }
            catch (Exception error)
            {
                return FilasAfectadas;
            }
        }

        public int Actualizar(int id, string Nombre, string Escuderia, string Pais)
        {
            int FilasAfectadas = 0;
            try
            {
                ConexionBD();
                SqlCommand Comando = new SqlCommand("SP_Actualizar",Conexion);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID", id);
                Comando.Parameters.AddWithValue("@Nombre", Nombre);
                Comando.Parameters.AddWithValue("@Escuderia", Escuderia);
                Comando.Parameters.AddWithValue("@Pais", Pais);
                FilasAfectadas=Comando.ExecuteNonQuery();
                Desconexion();
                return FilasAfectadas;
            }
            catch (Exception error)
            {
                return FilasAfectadas;
            }
        }

        public int Borrar(int id)
        {
            int FilasAfectadas = 0;
            try
            {
                ConexionBD();
                SqlCommand Comando = new SqlCommand("SP_Eliminar", Conexion);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID", id);
                FilasAfectadas = Comando.ExecuteNonQuery();
                Desconexion();
                return FilasAfectadas;
            }
            catch (Exception error)
            {
                return FilasAfectadas;
            }
        }

        public DataTable BuscarID(int id)
        {
            try
            {
                ConexionBD();
                DataTable Valor = new DataTable();
                SqlCommand Comando = new SqlCommand("SP_BuscarId", Conexion);
                Comando.CommandType= CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter Dato = new SqlDataAdapter(Comando);
                Dato.Fill(Valor);
                Desconexion();
                return Valor;
            }
            catch (Exception error)
            {

                return new DataTable();
            }
        }
    }
}
