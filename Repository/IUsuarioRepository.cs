using System.Collections.Generic;
using ApiCore.Models;

namespace ApiCore.Repository
{
    public interface IUsuarioRepository
    {
        void Add(Usuario user);
        IEnumerable<Usuario> GetAll();
        Usuario Find(long id);
        void Remove(long user);
        void Update(Usuario user);

    }
}