using ModelLayer.Entities;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms.PortableXaml.Models;

namespace XamarinForms.PortableXaml.Data
{
    public class GeaDataBase
    {
        static object locker = new object();

        SQLiteConnection database;


        public GeaDataBase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Usuario>();
            database.CreateTable<Configuraciones>();
            database.CreateTable<Position>();
        }

        public void deleteDBRegs()
        {
            database.DeleteAll<Usuario>();
            database.DeleteAll<Configuraciones>();
            database.DeleteAll<Position>();
        }

        public bool saveGeneric(object testObj)
        {
            bool salida = false;

            try
            {
                lock (locker)
                {
                    database.Insert(testObj, testObj.GetType());
                }
                salida = true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return salida;

        }

        public List<Position> getPositions()
        {
            lock (locker)
            {
                return database.Table<Position>().ToList();
            }
        }

        public void deletePositions() {
            database.DeleteAll<Position>();
        }

        public int saveUsers(IEnumerable<Usuario> usuarios)
        {
            lock (locker)
            {
                database.DeleteAll<Usuario>();
                database.InsertAll(usuarios);
            }
            return usuarios.Count();
        }

        public Usuario validateUser(string user, string pass)
        {
            var passHashed = EasyEncryption.MD5.ComputeMD5Hash(pass);
            var userActSession = database.Table<Usuario>().FirstOrDefault(x => x.User.ToLower() == user.ToLower() && x.Clave == passHashed);
            return userActSession;
        }

        public int countUsers()
        {
            return database.Table<Usuario>().Count();
        }

        public List<Configuraciones> getConfigs()
        {
            lock (locker)
            {
                return database.Table<Configuraciones>().ToList();
            }
        }

        public bool InsertConfigs(string configName, string configValue)
        {
            var salida = false;
            try
            {
                lock (locker)
                {
                    var config = new Configuraciones { ConfigName = configName, ConfigValue = configValue };
                    database.Insert(config);
                }
                salida = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return salida;
        }

        //public bool validLocalUser(string user, string pass)
        //{
        //    if (database.Table<USUARIO> != null)
        //    {

        //    }
        //}
    }
}
