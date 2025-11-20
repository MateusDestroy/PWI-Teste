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
        public class UsuarioController : ControllerBase
        {
            private readonly PwiContext _contextUser;
            
        public UsuarioController(PwiContext contextUser)
        {
            _contextUser = contextUser;
            
        }
       // procurando usuario por ID
        [HttpGet("{id}")]
        public IActionResult ObterUsuId(int id)
        {
            var usu = _contextUser.Tb_usuario.Find(id);


            if (usu == null)
            {
                return NotFound("Erro - Não encontrado");
            }


            return Ok(usu);
            
        }


        [HttpGet("ObterNomes")]
        public IActionResult ObterNomes(string nome)
        {
            var usu = _contextUser.Tb_usuario.Where(x => x.NmNick.Contains(nome));
            if (usu == null)
            {
                return NotFound();
            }
            return Ok(usu);
        }



        /// Criação de usuário para o chat

         [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            _contextUser.Add(usuario);
            _contextUser.SaveChanges();
            return Ok(usuario);
        }
 





       /// Alteração de Senha e email na parte de Esqueci senha, para tela de login e senha

        [HttpPut("{id}")]
        public IActionResult AtualizaUsuSenha(int id, Usuario usuario)
        {
            var usuBranco = _contextUser.Tb_usuario.Find(id);

            if(usuBranco == null)
            {
                return NotFound("Não consegui achar");
            }

            usuBranco.NmEmail =  usuario.NmEmail;
            usuBranco.NmSenha =  usuario.NmSenha;

            _contextUser.Tb_usuario.Update(usuBranco);
            _contextUser.SaveChanges();

            return Ok(usuBranco);
        }
        
 /// Deletando sala do banco de dados 
        

    [HttpDelete("{id}")]
    public IActionResult DeletarUser(int id)
        {
            var usuarioBranco = _contextUser.Tb_usuario.Find(id);

            if(usuarioBranco == null)
            {
                return NotFound("Não consegui achar");
            }

            _contextUser.Tb_usuario.Remove(usuarioBranco);
            _contextUser.SaveChanges();
            return NoContent();
        }
 
    }
}
