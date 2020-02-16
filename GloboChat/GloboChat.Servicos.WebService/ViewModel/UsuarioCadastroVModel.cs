using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboChat.Servicos.WebService.ViewModel
{
    public class UsuarioCadastroVModel
    {
        public string Nome { get; set; }
        public string DataNasc { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
    }
}
