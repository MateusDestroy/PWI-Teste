using Microsoft.AspNetCore.Mvc;
using TreinoC_.Entities;
using System.Collections.Generic;
using System.Linq;

namespace TreinoC_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        // Simulação de banco de dados em memória
        private static List<Usuario> usuarios = new List<Usuario>();

        // GET: api/usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(usuarios);
        }

        // GET: api/usuario/{id}
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
                return NotFound(new { message = "Usuário não encontrado" });

            return Ok(usuario);
        }

        // POST: api/usuario
        [HttpPost]
        public ActionResult<Usuario> CreateUsuario([FromBody] Usuario novoUsuario)
        {
            novoUsuario.IdUsuario = usuarios.Count > 0 ? usuarios.Max(u => u.IdUsuario) + 1 : 1;
            usuarios.Add(novoUsuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuario.IdUsuario }, novoUsuario);
        }

        // PUT: api/usuario/{id}
        [HttpPut("{id}")]
        public ActionResult<Usuario> UpdateUsuario(int id, [FromBody] Usuario usuarioAtualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
                return NotFound(new { message = "Usuário não encontrado" });

            usuario.NmEmail = usuarioAtualizado.NmEmail;
            usuario.NmSenha = usuarioAtualizado.NmSenha;
            usuario.NmNick = usuarioAtualizado.NmNick;
            usuario.Dsmensagem = usuarioAtualizado.Dsmensagem;

            return Ok(usuario);
        }

        // DELETE: api/usuario/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
                return NotFound(new { message = "Usuário não encontrado" });

            usuarios.Remove(usuario);
            return Ok(new { message = "Usuário removido com sucesso" });
        }
    }
}
