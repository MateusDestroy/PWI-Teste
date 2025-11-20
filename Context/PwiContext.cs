using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreinoC_.Entities;


namespace TreinoC_.Context
{
    public class PwiContext : DbContext
    {
        public PwiContext (DbContextOptions<PwiContext> options) : base(options)
        {
            
        }


        public DbSet<Sala> Tb_salas{get; set;}
        public DbSet<Usuario> Tb_usuario{get; set;}
        public DbSet<Chat> Tb_chat{get; set;}



      
    }
}