
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
        // listando chats dentro do meu banco de dados 
        private static List<Chat> chats = new List<Chat>();

        // GET: chat exibindo chats 
        [HttpGet]
        public ActionResult<IEnumerable<Chat>> GetChats()
        {
            return Ok(chats);
        }

        // GET: chat/{id} separando chat por {id}
        [HttpGet("{id}")]
        public ActionResult<Chat> GetChat(int id)
        {
            var chat = chats.FirstOrDefault(c => c.Idchat == id);
            if (chat == null)
                return NotFound(new { message = "Chat não encontrado" });

            return Ok(chat);
        }

        // POST: chat/ post por id e sala em cada chat 
        [HttpPost]
        public ActionResult<Chat> CreateChat([FromBody] Chat novoChat)
        {
            novoChat.Idchat = chats.Count > 0 ? chats.Max(c => c.Idchat) + 1 : 1;
            chats.Add(novoChat);
            return CreatedAtAction(nameof(GetChat), new { id = novoChat.Idchat }, novoChat);
        }
    }
}
