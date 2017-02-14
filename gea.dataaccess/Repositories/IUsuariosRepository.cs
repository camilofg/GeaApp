using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Entities;
using System.Data;

namespace gea.dataaccess.Repositories
{
    public interface IUsuariosRepository
    {
        IList<Usuario> GetAllUsuarios(/*string query, int page, int pageSize*/);
        DataTable getAlgo(string tableName);
        long GetNumberOfContacts(string query);
        bool UsuarioValidate(string User, string Clave);
        bool UsuarioExists(string email);
        Usuario GetUsuarioById(int id);
        Usuario GetUsuarioByEmail(string email);
        long Insert( Usuario usuario);
        void Update(int id, Usuario usuario);
        void Delete(int id);
    }
}
