using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Dominio.Entidades
{
    public class SalaChat
    {
        public int IdChat { get; set; }
        public Chat Chat { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
