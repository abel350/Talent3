﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Talento.Models;

namespace Talento.Clases
{
    public class Usuarios
    {


        public static void InsertaUsuario( string Membresia, string Nombre, string Correo, string Ciudad, string UID )
        {

            SqlConnection cn = new SqlConnection("Server = 192.168.0.100; Database = Bd_Talento; Trusted_Connection = True; MultipleActiveResultSets = true");
            SqlCommand consulta = new SqlCommand(string.Format("INSERT INTO [dbo].[Users] ([Membresia],[Apaterno],[Amaterno],[Nombre],[Empresa],[GiroEmpresa],[Puesto],[telefono],[Correo],[Ciudad],[TipoMembresia],[fechaIngreso],[UID]) VALUES (@Membresia, @Apaterno, @Amaterno, @Nombre, @Empresa, @GiroEmpresa, @Puesto, @Telefono, @Correo, @Ciudad, @TipoMemebresia, @FechaIngreso, @UID)"), cn);
            consulta.Parameters.AddWithValue("@Membresia", Membresia);
            consulta.Parameters.AddWithValue("@Apaterno", "");
            consulta.Parameters.AddWithValue("@Amaterno", "");
            consulta.Parameters.AddWithValue("@Nombre", Nombre);
            consulta.Parameters.AddWithValue("@Empresa", "");
            consulta.Parameters.AddWithValue("@GiroEmpresa", "");
            consulta.Parameters.AddWithValue("@Puesto", "");
            consulta.Parameters.AddWithValue("@Telefono", "");
            consulta.Parameters.AddWithValue("@Correo", Correo);
            consulta.Parameters.AddWithValue("@Ciudad", Ciudad);
            consulta.Parameters.AddWithValue("@TipoMemebresia", "Silver");
            consulta.Parameters.AddWithValue("@FechaIngreso", DateTime.Now);
            consulta.Parameters.AddWithValue("@UID", UID);
            cn.Open();
            consulta.ExecuteNonQuery();
            cn.Close();
        }

        public static DataTable DatosUsuario(string user)
        {

            SqlConnection cn = new SqlConnection("Server = 192.168.0.100; Database = Bd_Talento; Trusted_Connection = True; MultipleActiveResultSets = true");

            SqlCommand consulta = new SqlCommand(string.Format("SELECT * FROM Users WHERE UID =@UID"), cn);
            consulta.Parameters.AddWithValue("@UID", user);
            SqlDataAdapter da = new SqlDataAdapter(consulta);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

    }
}
