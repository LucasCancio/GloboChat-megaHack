using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboChat.Dominio.Interfaces.Repositorios;
using GloboChat.Servicos.WebService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboChat.Servicos.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public IActionResult Logar([FromBody]LoginViewModel lvm)
        {
            var logado = _loginRepository.Logar(lvm.CPF,lvm.Senha);
            if (logado)
                return Ok();
            else
                return BadRequest("Usuario e/ou senha inválidos!");
        }
    }
}