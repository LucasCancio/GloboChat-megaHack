using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboChat.Servicos.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Usuario user)
        {
            try
            {
                _usuarioRepository.Insert(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Usuario user)
        {
            try
            {
                _usuarioRepository.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public Usuario GetById(int id)
        {
            var user = _usuarioRepository.SelectById(id);
            return user;
        }

        [HttpGet]
        [Route("{cpf}")]
        public Usuario GetByCPF(string cpf)
        {
            var user = _usuarioRepository.SelectByCPF(cpf);
            return user;
        }

        [HttpPost]
        [Route("senha/{id}")]
        public IActionResult AlterarSenha(int id, [FromBody]string novaSenha)
        {
            try
            {
                _usuarioRepository.AlterarSenha(id, novaSenha);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }

        [HttpPost]
        [Route("telefone/{id}")]
        public IActionResult AlterarTelefone(int id, [FromBody]string novoCelular)
        {
            try
            {
                _usuarioRepository.AlterarTelefone(id,novoCelular);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}