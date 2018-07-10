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
    }
}