using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 


/// Criação de nossas tabelas para  usar migrations e passar tudo para o Sql Server

namespace TreinoC_.Entities
{
    public class Chat
    {

        [Key]
        public int Idchat{get; set;}
    
         public  int IdSala { get; set; }
         public  int IdUsuario { get; set; }


        
    }
}
