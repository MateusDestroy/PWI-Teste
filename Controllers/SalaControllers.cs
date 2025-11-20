using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TreinoC_.Context;
using TreinoC_.Entities;

namespace TreinoC_.Controllers
{
    public interface ISalaController
    {
        IActionResult Create(Sala sala);
    }

    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly PwiContext _contextSala;

        public SalaController(PwiContext contextSala)
        {
            _contextSala = contextSala;

        }


        // procurando sala por ID

        [HttpGet("{id}")]
        public IActionResult ObterSalaID(int id)
        {
            var sala = _contextSala.Tb_salas.Find(id);
            return Ok(sala);
            
        }












        // Criação de sala para o chat - nos teste coloquei meu nome e coloque que sou lindo

        [HttpPost]
        public IActionResult Create(Sala sala)
        {
            _contextSala.Add(sala);
            _contextSala.SaveChanges();
            return Ok(sala);
        }


        /// Para Alterar o nome da sala e alterar a ativação da sala

          [HttpPut("{id}")]
        public IActionResult AtualizaUsuSenha(int id, Sala sala)
        {
            var salaBranco = _contextSala.Tb_salas.Find(id);

            if(salaBranco == null)
            {
                return NotFound("Não consegui achar");
            }

            salaBranco.Nmsala =  sala.Nmsala;
            salaBranco.Blativo =  sala.Blativo;

            _contextSala.Tb_salas.Update(salaBranco);
            _contextSala.SaveChanges();

            return Ok(salaBranco);
        }


 /// Deletando sala do banco de dados 
        

    [HttpDelete("{id}")]
    public IActionResult DeletarSala(int id)
        {
            var salaBranco = _contextSala.Tb_salas.Find(id);

            if(salaBranco == null)
            {
                return NotFound("Não consegui achar");
            }

            _contextSala.Tb_salas.Remove(salaBranco);
            _contextSala.SaveChanges();
            return NoContent();
        }
 
    }
        
        
    
}