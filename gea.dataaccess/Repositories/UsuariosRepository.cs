using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Entities;
using Npgsql;
using System.Data;

namespace gea.dataaccess.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private string connStr = "Server=Localhost;Port=5432;User id=servimeters;Password=admin;Database=servimetersdb;CommandTimeout=480;Timeout=480;";
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public IList<Usuario> GetAllUsuarios()
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM  \"SYS_USUARIO\"";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);
                var list = ConvertUsuariosTab(dt);
                conn.Close();
                return list;
            }
        }

        public DataTable getAlgo(string tableName) {
            using (var conn = new NpgsqlConnection(connStr))
            {
                //SRV_ESCALERA_INSPECTOR
                conn.Open();
                string sql = "SELECT * FROM  \"" + tableName + "\"";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }

        }

        public bool UsuarioValidate(string User, string Clave)
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string sql = String.Format("SELECT * FROM  \"SYS_USUARIO\" WHERE \"USUARIO\" = '{0}'", User);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt.Rows.Count > 0 ? true : false;
            }
        }

        private List<Usuario> ConvertUsuariosTab(DataTable dt)
        {

            var convertedList = (from rw in dt.AsEnumerable()
                                 select new Usuario()
                                 {
                                     Id = Convert.ToInt32(rw["ID_USUARIO"]),
                                     User = rw["USUARIO"].ToString(),
                                     Clave = rw["CLAVE"].ToString(),
                                     Apellido = rw["APELLIDO"].ToString(),
                                     Nombre = rw["NOMBRE"].ToString(),
                                     Correo = rw["CORREO"].ToString(),
                                     Activo = (rw["ACTIVO"]).ToString() == "SI" ? true : false,
                                     Logo = rw["LOGO"].ToString(),
                                     FechaRegistro = (DateTime)(rw["FECHA_REGISTRO"])
                                 }).ToList();

            return convertedList;
        }

        public long GetNumberOfContacts(string query)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool UsuarioExists(string email)
        {
            throw new NotImplementedException();
        }

    }
}
