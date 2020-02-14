using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GloboChat.Dominio.Entidades
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

        public Login login { get; set; }
        public bool Ativo { get; set; }

        public virtual IEnumerable<SalaChat> SalasChat { get; set; } = new HashSet<SalaChat>();
    }
}
