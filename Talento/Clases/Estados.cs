using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Talento.Clases
{
    public class Estados
    {
        public static IConfiguration Configuration { get; }


        static public string Abreviatura(string estado)
        {
            switch (estado)
            {
                case "Aguascalientes": return "AGS"; 
                case "Baja California": return "BCN";
                case "Baja California Sur": return "BCS";
                case "Campeche": return "CAM";
                case "Chiapas": return "CHP";
                case "Chihuahua": return "CHH";
                case "Coahuila": return "COA";
                case "Colima": return "COL";
                case "Ciudad de México": return "CMX3";
                case "Durango": return "DUR";
                case "Guanajuato": return "GUA";
                case "Guerrero": return "GRO";
                case "Hidalgo": return "HID";
                case "Jalisco": return "JAL";
                case "México": return "MEX";
                case "Michoacán": return "MIC";
                case "Morelos": return "MOR";
                case "Nayarit": return "NAY";
                case "Nuevo León": return "NLE";
                case "Oaxaca": return "OAX";
                case "Puebla": return "PUE";
                case "Querétaro": return "QUE";
                case "Quintana Roo": return "ROO";
                case "San Luis Potosí": return "SLP";
                case "Sinaloa": return "SIN";
                case "Sonora": return "SON";
                case "Tabasco": return "TAB";
                case "Tamaulipas": return "TAM";
                case "Tlaxcala": return "TLA";
                case "Veracruz": return "VER";
                case "Yucatán": return "YUC";
                case "Zacatecas": return "ZAC";
                default:
                    return "Error";
            }
            
        }

           public static DataTable Consec (string Estado)
        {

            SqlConnection cn = new SqlConnection("Server = 192.168.0.100; Database = Bd_Talento; Trusted_Connection = True; MultipleActiveResultSets = true");

            SqlCommand consulta = new SqlCommand(string.Format("SELECT Consecutivo  FROM Estados  where estado = @Edo"), cn);
                consulta.Parameters.AddWithValue("@Edo", Estado);
                SqlDataAdapter da = new SqlDataAdapter(consulta);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
        }

    
            public static DataTable DatosEstados()
                 {
                         
                SqlConnection cn = new SqlConnection("Server = 192.168.0.100; Database = Bd_Talento; Trusted_Connection = True; MultipleActiveResultSets = true");

                SqlCommand consulta = new SqlCommand(string.Format("SELECT * FROM Estados"), cn);
                    SqlDataAdapter da = new SqlDataAdapter(consulta);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }


        public static void ActualizarConsecutivo(int Cons, string estado)
        {

            SqlConnection cn = new SqlConnection("Server = 192.168.0.100; Database = Bd_Talento; Trusted_Connection = True; MultipleActiveResultSets = true");
            SqlCommand consulta = new SqlCommand(string.Format("UPDATE [dbo].[Estados] SET Consecutivo = @consec WHERE Estado = @Edo "), cn);
            consulta.Parameters.AddWithValue("@consec", Cons);
            consulta.Parameters.AddWithValue("@Edo", estado);
            cn.Open();
            consulta.ExecuteNonQuery();
            cn.Close();
        }





    }
}
