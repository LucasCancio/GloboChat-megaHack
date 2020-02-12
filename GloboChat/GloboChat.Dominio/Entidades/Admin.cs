using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GloboChat.Dominio.Entidades
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Login login { get; set; }
    }
}
