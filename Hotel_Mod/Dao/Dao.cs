using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Hotel_Mod.Class
{
    public abstract class Dao<T>
    {
        protected string connectionString;

        public Dao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        }
        public abstract List<T> GetAll(bool ativos = false);
        public abstract void Salvar(T obj);
        public abstract void alterar(T obj);
        public abstract void excluir(int id);
        public abstract T pesquisar(int id);

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
