using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data.SqlClient;

namespace Negocio
{
    public class Bussines
    {
        static Data1 con = new Data1();

        public List<ModelPilotos> Mostrar()
        {
            try
            {
                Data1 con1 = new Data1();
                List<ModelPilotos> Lista = new List<ModelPilotos>();
                DataTable Tabla = con1.Mostar();
                foreach (DataRow Valor in Tabla.Rows)
                {
                    ModelPilotos p = new ModelPilotos();
                    p.ID=Convert.ToInt32(Valor["ID"]);
                    p.Nombre= Valor["Nombre"].ToString();
                    p.Escuderia= Valor["Escuderia"].ToString();
                    p.Pais= Valor["Pais"].ToString();
                   
                    Lista.Add(p);
                }   
                return Lista;
            }
            catch (Exception error)
            {
                return new List<ModelPilotos>();
            }
        }

        public string Insertar(string Nombre, string Escuderia, string Pais)
        {
            int Respuesta = con.Insertar(Nombre, Escuderia, Pais);
            if (Respuesta == 1)
            {
                return "Agregado con Exito";
            }
            else
                return "Error al Agregar";
        }

        public string Actualizar(int id, string Nombre, string Escuderia, string Pais)
        {
            int Respuesta = con.Actualizar(id,Nombre, Escuderia, Pais);
            if (Respuesta == 1)
            {
                return "Actualizado con Exito";
            }
            else
                return "Error al Actualizado";
        }
        public string Borrar (int id)
        {
            int Respuesta = con.Borrar(id);
            if (Respuesta == 1)
            {
                return "Boarrdo con Exito";
            }
            else
                return "Error al Borrar";
        }
        public ModelPilotos BuscarID(int id)
        {
            try
            {
                ModelPilotos Piloto = new ModelPilotos();
                DataTable Tabla = con.BuscarID(id);
                foreach (DataRow Valor in Tabla.Rows)
                {
                    Piloto.ID = Convert.ToInt32(Valor["ID"]);
                    Piloto.Nombre = Valor["Nombre"].ToString();
                    Piloto.Escuderia = Valor["Escuderia"].ToString();
                    Piloto.Pais = Valor["Pais"].ToString();
                }
                return Piloto;
            }
            catch (Exception error)
            {
                return new ModelPilotos();
            }
        }

    }
}
