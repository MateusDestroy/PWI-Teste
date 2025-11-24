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
        // Simulação de banco de dados em memória
        private static List<Sala> salas = new List<Sala>();

        // GET: api/sala
        [HttpGet]
        public ActionResult<IEnumerable<Sala>> GetSalas()
        {
            return Ok(salas);
        }

        // GET: api/sala/{id}
        [HttpGet("{id}")]
        public ActionResult<Sala> GetSala(int id)
        {
            var sala = salas.FirstOrDefault(s => s.IdSala == id);
            if (sala == null)
                return NotFound(new { message = "Sala não encontrada" });

            return Ok(sala);
        }

        // POST: api/sala
        [HttpPost]
        public ActionResult<Sala> CreateSala([FromBody] Sala novaSala)
        {
            novaSala.IdSala = salas.Count > 0 ? salas.Max(s => s.IdSala) + 1 : 1;
            salas.Add(novaSala);
            return CreatedAtAction(nameof(GetSala), new { id = novaSala.IdSala }, novaSala);
        }

        // PUT: api/sala/{id}
        [HttpPut("{id}")]
        public ActionResult<Sala> UpdateSala(int id, [FromBody] Sala salaAtualizada)
        {
            var sala = salas.FirstOrDefault(s => s.IdSala == id);
            if (sala == null)
                return NotFound(new { message = "Sala não encontrada" });

            sala.Nmsala = salaAtualizada.Nmsala;
            sala.Blativo = salaAtualizada.Blativo;

            return Ok(sala);
        }

        // DELETE: api/sala/{id}
        [HttpDelete("{id}")]
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
