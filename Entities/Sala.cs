using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

/// Criação de nossas tabelas para  usar migrations e passar tudo para o Sql Server

namespace TreinoC_.Entities
{
    public class Sala
    {

        [Key]
        public int      IdSala {get; set;}
        public string?   Nmsala{get; set;}
        public bool      Blativo{get ; set;}
        
       
      


        
        
    }
}
