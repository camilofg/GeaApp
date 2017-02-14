using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSServimeterSGS.Models;
using Newtonsoft.Json;
using gea.dataaccess;
using ModelLayer.Entities;
using gea.dataaccess.Repositories;
using System.Collections;
using System.Data;

namespace WSServimeterSGS.Controllers
{
    public class UserController : ApiController
    {
        static readonly IUsuariosRepository repository = new UsuariosRepository();
        //[Route("User/{customerId}/orders")]
        [HttpGet]
        public IList<Usuario> Get()
        {
            var AllUsers = repository.GetAllUsuarios();
            return AllUsers;
        }

        [HttpPost]
        public bool ValidateUser(us user)
        {
            return repository.UsuarioValidate(user.usuario, user.password); 
        }

        [HttpPost]
        public DataTable testCF(string tableName) {
            return repository.getAlgo(tableName);
        }

        public class us {
            public string usuario { get; set; }
            public string password { get; set; }
        }

        // GET: api/User/5
        public Usuario Get(int id)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            using (var conn = new NpgsqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["geaDataBase"].ToString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    try
                    {

                        cmd.Connection = conn;
                    
                        cmd.CommandText = "select * from \"SYS_USUARIO\"";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var usuario = new Usuario { Id = reader.GetInt32(0),User = reader.GetString(1) };
                                listaUsuarios.Add(usuario);
                            }
                        }
                        return listaUsuarios[0];

                    }
                    catch (Exception ex)
                    {
                        
                        
                        throw ex;
                    }
                }
            }
        }

            

        // POST: api/User
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/User/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/User/5
        //public void Delete(int id)
        //{
        //}
    }
}
