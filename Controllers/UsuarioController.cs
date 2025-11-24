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
        // Listando todos os usuario
        private static List<Usuario> usuarios = new List<Usuario>();

        // GET: usuario - listando todos os usuario 
        [HttpGet("ObterUsuarios")]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(usuarios);
        }   

        // GET: usuario/{id} -  listando usuario por id 
        [HttpGet("ObterUsuarioPor/{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
                return NotFound(new { message = "Usuário não encontrado" });

            return Ok(usuario);
        }

        // POST: usuario - colocando usuario dentro do banco de dados
        [HttpPost("CriarUsuario")]
        public ActionResult<Usuario> CreateUsuario([FromBody] Usuario novoUsuario)
        {
            novoUsuario.IdUsuario = usuarios.Count > 0 ? usuarios.Max(u => u.IdUsuario) + 1 : 1;
            usuarios.Add(novoUsuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuario.IdUsuario }, novoUsuario);
        }

        // PUT: usuario/{id} - alterando usuario dentro do banco de dados 
        [HttpPut("AlterarUsuarioPor/{id}")]
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

        // DELETE: usuario/{id} - deletando usuario dentro do banco.
        [HttpDelete("DeletarUsuarioPor/{id}")]
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
