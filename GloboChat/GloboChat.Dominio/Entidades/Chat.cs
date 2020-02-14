using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GloboChat.Dominio.Entidades
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }     
        public string ProgramaAtual { get; set; }
        public string Titulo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }


        public virtual IEnumerable<SalaChat> SalasChat { get; set; } = new HashSet<SalaChat>();

    }
}
