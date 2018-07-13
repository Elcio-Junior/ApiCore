using System.Collections.Generic;
using ApiCore.Models;
using ApiCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepositorio;

        public UsuariosController(IUsuarioRepository _usuarioRepo)
        {
            _usuarioRepositorio = _usuarioRepo;

        }
        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(long id)
        {
            var user = _usuarioRepositorio.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuário invalido");

            }
            _usuarioRepositorio.Add(usuario);

            return CreatedAtRoute("GetUsuario", new { id = usuario.UsuarioID }, usuario);

        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.UsuarioID != id)
            {
                return BadRequest("Usuário diferente");

            }
            var _user = _usuarioRepositorio.Find(id);

            if (_user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            _user.Email = usuario.Email;
            _user.Nome = usuario.Nome;

            _usuarioRepositorio.Update(_user);
            return new NoContentResult();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _usuarioRepositorio.Find(id);

            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            _usuarioRepositorio.Remove(id);
            return new NoContentResult();

        }

    }
}