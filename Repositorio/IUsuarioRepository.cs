using System.Collections.Generic;
using ProjetoCoreApi.Models;

namespace ProjetoCoreApi.Repositorio
{
    public interface IUsuarioRepository
    {
        void Add(Usuario user);

        IEnumerable<Usuario> GetALL();
        Usuario Find(long id);
        void Remove(long id);
        void Update(Usuario user);

    }
}