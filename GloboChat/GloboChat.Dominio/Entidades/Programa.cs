using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GloboChat.Dominio.Entidades
{
    public class Programa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFinal { get; set; }
    }
}
