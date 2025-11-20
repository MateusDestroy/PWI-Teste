using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreinoC_.Context;
using TreinoC_.Entities;

namespace TreinoC_.Controllers
{
       
        [ApiController]
        [Route("[controller]")]
        public class ChatController : ControllerBase
        {
            private readonly PwiContext _contextChat;
            
        public ChatController(PwiContext contextChat)
        {
            _contextChat = contextChat;
            
        }
       // procurando usuario por ID
        [HttpGet("{id}")]
        public IActionResult ObterChatId(int id)
        {
            var chat = _contextChat.Tb_chat.Find(id);


            if (chat == null)
            {
                return NotFound("Erro - Não encontrado");
            }


            return Ok(chat);
            
        }
    }

}