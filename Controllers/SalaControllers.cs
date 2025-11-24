using Microsoft.AspNetCore.Mvc;
using TreinoC_.Entities;
using System.Collections.Generic;
using System.Linq;

namespace TreinoC_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaController : ControllerBase
    {
        //listando usuario dentro do meu banco de dados 
        private static List<Sala> salas = new List<Sala>();

        // GET: sala listando todas as salas
        [HttpGet("ObterSalas")]
        public ActionResult<IEnumerable<Sala>> GetSalas()
        {
            return Ok(salas);
        }  

        // GET: sala/{id} separando salas por {id}
        [HttpGet("ObterSalaPor{id}")]
        public ActionResult<Sala> GetSala(int id)
        {
            var sala = salas.FirstOrDefault(s => s.IdSala == id);
            if (sala == null)
                return NotFound(new { message = "Sala não encontrada" });

            return Ok(sala);
        }

        // POST: sala inserindo diferente salas 
        [HttpPost("CriarSala")]
        public ActionResult<Sala> CreateSala([FromBody] Sala novaSala)
        {
            novaSala.IdSala = salas.Count > 0 ? salas.Max(s => s.IdSala) + 1 : 1;
            salas.Add(novaSala);
            return CreatedAtAction(nameof(GetSala), new { id = novaSala.IdSala }, novaSala);
        }

        // PUT: sala/{id} alterando informações de sala
        [HttpPut("AlterarSalaPor{id}")]
        public ActionResult<Sala> UpdateSala(int id, [FromBody] Sala salaAtualizada)
        {
            var sala = salas.FirstOrDefault(s => s.IdSala == id);
            if (sala == null)
                return NotFound(new { message = "Sala não encontrada" });

            sala.Nmsala = salaAtualizada.Nmsala;
            sala.Blativo = salaAtualizada.Blativo;

            return Ok(sala);
        }

        // DELETE: sala/{id} deletando salas - uma melhoria que colocaria se eu descobri era de deletar sala por ativo e desativo
        [HttpDelete("DeletarSalaPor{id}")]
        public ActionResult DeleteSala(int id)
        {
            var sala = salas.FirstOrDefault(s => s.IdSala == id);
            if (sala == null)
                return NotFound(new { message = "Sala não encontrada" });

            salas.Remove(sala);
            return Ok(new { message = "Sala removida com sucesso" });
        }
    }
}
