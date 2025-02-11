﻿using System.ComponentModel.DataAnnotations;

namespace GloboChat.Servicos.WebService.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O CPF é obrigatorio!")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "A Senha é obrigatoria!")]
        public string Senha { get; set; }
    }
}
