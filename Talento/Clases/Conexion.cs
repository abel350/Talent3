using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Talento.Clases
{
    public class Conexion
    {
        SqlConnection SqlConn;

        //public SqlConnection ObtenerConexion()

        //{ 


        //         return   SqlConn = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));//IConfigurationManager.ConnectionStrings["SMARTDATA"].ConnectionString);

        //}
        public static IConfiguration Configuration { get; set; }


        public SqlConnection ObtenerConexion()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return SqlConn = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));

        }





        private void Conectar()

        {

            try

            {

                if (SqlConn.State == ConnectionState.Closed) SqlConn.Open();

            }

            catch (InvalidCastException ex)

            {

                throw (ex);

            }

        }

        private void Desconectar()

        {

            try

            {

                if (SqlConn.State == ConnectionState.Open) SqlConn.Close();

            }

            catch (InvalidCastException ex)

            {

                throw (ex);

            }

        }

        public DataTable ConsultaUsuarioDominio(String Usuario)

        {

            Conectar();

            DataTable Respuesta = new DataTable();

            SqlCommand command = new SqlCommand("TSP_LAUNCHER_ConsultaUsuarioDominio", SqlConn);

            command.CommandType = CommandType.StoredProcedure;

            command.CommandTimeout = 30000;

            command.Parameters.AddWithValue("@Valor", Usuario);

            SqlDataReader DR = command.ExecuteReader();

            Respuesta.Load(DR);

            Desconectar();

            return Respuesta;

        }
    }
}
