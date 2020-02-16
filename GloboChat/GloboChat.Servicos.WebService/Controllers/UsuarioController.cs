using System;
using AutoMapper;
using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using GloboChat.Servicos.WebService.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GloboChat.Servicos.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _usuarioRepository;
        IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody]UsuarioCadastroVModel userVModel)
        {
            try
            {
                userVModel.CPF = userVModel.CPF.Replace(".", "").Replace("-", "");

                var login = _mapper.Map<Login>(userVModel);
                var pessoa= _mapper.Map<Pessoa>(userVModel);
                var user = _mapper.Map<Usuario>(userVModel);
                pessoa.login = login;
                user.pessoa = pessoa;

                _usuarioRepository.Insert(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]UsuarioViewModel userVModel)
        {
            try
            {           
                var login = _mapper.Map<Login>(userVModel);
                var pessoa = _mapper.Map<Pessoa>(userVModel);
                var user = _mapper.Map<Usuario>(userVModel);
                pessoa.login = login;
                user.pessoa = pessoa;

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
        public IActionResult GetById(int id)
        {
            var user = _usuarioRepository.SelectById(id);
            if (user==null)
                return Ok(user);
            else
                return NotFound(user);
        }

        [HttpGet]
        [Route("teste")]
        public IActionResult Teste()
        {
            return Ok("testado");
        }

        [HttpGet]
        [Route("all")]
        public IActionResult SelectAll()
        {
            return Ok(_usuarioRepository.Select());
        }

        [HttpGet]
        [Route("cpf/{cpf}")]
        public IActionResult GetByCPF(string cpf)
        {
            var user = _usuarioRepository.SelectByCPF(cpf);
            if (user == null)
                return Ok(user);
            else
                return NotFound(user);
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
        public IActionResult AlterarTelefone(int id, [FromBody]string telefone)
        {
            try
            {
                _usuarioRepository.AlterarTelefone(id, telefone);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}