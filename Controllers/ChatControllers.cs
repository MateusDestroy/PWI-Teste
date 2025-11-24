
using Microsoft.AspNetCore.Mvc;
using TreinoC_.Entities;
using System.Collections.Generic;
using System.Linq;

namespace TreinoC_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        // Simulação de banco de dados em memória
        private static List<Chat> chats = new List<Chat>();

        // GET: api/chat
        [HttpGet]
        public ActionResult<IEnumerable<Chat>> GetChats()
        {
            return Ok(chats);
        }

        // GET: api/chat/{id}
        [HttpGet("{id}")]
        public ActionResult<Chat> GetChat(int id)
        {
            var chat = chats.FirstOrDefault(c => c.Idchat == id);
            if (chat == null)
                return NotFound(new { message = "Chat não encontrado" });

            return Ok(chat);
        }

        // POST: api/chat
        [HttpPost]
        public ActionResult<Chat> CreateChat([FromBody] Chat novoChat)
        {
            novoChat.Idchat = chats.Count > 0 ? chats.Max(c => c.Idchat) + 1 : 1;
            chats.Add(novoChat);
            return CreatedAtAction(nameof(GetChat), new { id = novoChat.Idchat }, novoChat);
        }
    }
}
