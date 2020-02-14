using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GloboChat.Dominio.Entidades
{
    public class Canal
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public virtual IEnumerable<Chat> Chats { get; set; } = new HashSet<Chat>();
    }
}
