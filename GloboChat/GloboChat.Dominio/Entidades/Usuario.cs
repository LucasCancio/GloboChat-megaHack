using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GloboChat.Dominio.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }     
        public string UF { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public Pessoa pessoa { get; set; }

    }
}
