using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GloboChat.Servicos.WebService.ViewModel
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public string UF { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
    }
}
