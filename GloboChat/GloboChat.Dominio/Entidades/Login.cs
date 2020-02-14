using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GloboChat.Dominio.Entidades
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public NivelAcesso nivelAcesso { get; set; }
    }
    public enum NivelAcesso
    {
        Admin = 0,
        Moderador = 1,
        Telespectador = 2
    }
}
