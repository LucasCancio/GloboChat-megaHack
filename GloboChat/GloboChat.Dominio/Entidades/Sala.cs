using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GloboChat.Dominio.Entidades
{
    public class Sala
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<Moderador> Moderadores { get; set; }
        public Programa ProgramaAtual { get; set; }
        public string UF { get; set; }

    }
}
