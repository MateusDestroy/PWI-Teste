using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TreinoC_.Entities
{
    public class Usuario
    {

        [Key]
        public int IdUsuario {get; set;}
        public string? NmEmail {get; set;}
        public string? NmSenha {get; set;}
        public string? NmNick {get; set;}

        public string? Dsmensagem {get; set;}



    }
}