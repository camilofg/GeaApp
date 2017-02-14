using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WSServimeterSGS.Models;
using XamarinForms.PortableXaml.Models;

namespace gea.dataaccess
{
    public class QueryDBcs
    {
        List<IUsuario> users;
        private string connStr = "Server=35.162.0.224;Port=5432;User id=servimeters;Password=admin;Database=servimetersdb;CommandTimeout=480;Timeout=480;";
        public DataTable consultaUsuario(List<IUsuario> us)
        {
            users = us;
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM  \"SYS_USUARIO\"";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);
                var listUsuarios = new List<IUsuario>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    users.Add(new IUsuario {  })
                //}
                conn.Close();
                return dt;
            }
        }
    }
}
