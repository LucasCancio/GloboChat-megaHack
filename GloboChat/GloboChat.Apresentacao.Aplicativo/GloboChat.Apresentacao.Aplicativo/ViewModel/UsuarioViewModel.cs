using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GloboChat.Apresentacao.Aplicativo.ViewModel
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatorio!")]
        public string Nome { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "A Data de Nascimento é obrigatoria!")]
        public DateTime DataNasc { get; set; }
        [Required(ErrorMessage = "O Telefone é obrigatorio!")]
        public string Telefone { get; set; }

        public string UF { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
    }
}
