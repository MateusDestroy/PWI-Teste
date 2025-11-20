using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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