using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Class
{
    public abstract class controllerPai<T>
    {
        public abstract List<T> GetAll(bool inativos);
        public abstract void salvar(T obj);
        public abstract void excluir(int idobj);
        public abstract void alterar(T obj);
        public abstract T pesquisar(int id);

    }
}
